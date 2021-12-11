using GTANetworkAPI;
using HitSync.WeaponHitSync.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HitSync.WeaponHitSync
{
    sealed class HitSync : Script
    {
        private List<WeaponData> weaponsFromDb = new List<WeaponData>();

        [ServerEvent(Event.ResourceStart)]
        private Task OnResourceStart()
        {
            //TO ADD BY YOURSELF : LOAD WEAPON DATA FROM DATABASE

            return Task.CompletedTask;
        }
        
        [RemoteEvent("server:Sync:PlayerHit")]
        private Task OnPlayerHit(Player player, Player target)
        {
            if (player == null || target == null) return Task.CompletedTask;
            
            //ADD CHECK IF TARGET OR PLAYER IS DEAD
            WeaponHash usedWeapon = player.CurrentWeapon;

            //ADD WEAPONBLACKLIST IF YOU WANT
            WeaponData usedWeaponData = weaponsFromDb.FirstOrDefault(w => w.WeaponName == usedWeapon);
            if (usedWeaponData == null) return Task.CompletedTask;

            int targetHealth = target.Armor + target.Health;

            if (targetHealth - usedWeaponData.WeaponDamage <= 0)
            {
                //PLAYER IS DEAD -> CODE CUSTOM DEATHHANDLER
            }
            else
            {
                if (target.Armor > 0)
                {
                    if (target.Armor - usedWeaponData.WeaponDamage < 0)
                    {
                        int damageToDeal = usedWeaponData.WeaponDamage + target.Armor;
                        target.Health -= damageToDeal;
                        target.Armor = 0;
                    }
                    else
                    {
                        target.Armor -= usedWeaponData.WeaponDamage;
                    }
                }
                else
                {
                    target.Health -= usedWeaponData.WeaponDamage;
                }
            }

            return Task.CompletedTask;
        }
    }
}
