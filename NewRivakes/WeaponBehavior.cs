using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public interface WeaponBehavior
    {
        void useWeapon();
    }

    public class HeadEquipBehavior : WeaponBehavior
    {
        public HeadEquipBehavior() { }
        public void useWeapon()
        {
            Console.WriteLine("你装备了头部装备，给予头部有效的保护"); 
        }
    }
    public class BodyEquipBehavior : WeaponBehavior
    {
        public BodyEquipBehavior() { }
        public void useWeapon()
        {
            Console.WriteLine("你装备了护身装备, 给与身体有效的保护");
        }
    }
    public class FootEquipBehavior : WeaponBehavior
    {
        public FootEquipBehavior() { }
        public void useWeapon()
        {
            Console.WriteLine("你装备了脚本装备, 能够提升大幅度灵活性");
        }
    }

    public class WeaponEquipBehavior : WeaponBehavior
    {
        public WeaponEquipBehavior() { }
        public void useWeapon()
        {
            Console.WriteLine("你装备了武器装备, 你的攻击力得到大幅度提升");
        }
    }

}
