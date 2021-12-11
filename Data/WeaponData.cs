using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitSync.WeaponHitSync.Data
{
    public sealed class WeaponData
    {
        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; }
        public int WeaponMultiplier { get; set; } 

        public WeaponData(string WeaponName, int WeaponDamage, int WeaponMultiplier)
        {
            this.WeaponName = WeaponName;
            this.WeaponDamage = WeaponDamage;
            this.WeaponMultiplier = WeaponMultiplier;
        }
    }
}
