using System.Drawing;

namespace NewAdventureGame
{
    public class Weapon:Player
    {
        public static Weapon[] weapons;    //数组
        public int num = 0;           //数量
        public string name = "";      //名称
        public string description = "";//描述
        public Bitmap bitmap;          //显示
        public int isdepletion = 1;   //表示物品是否是消耗类型的物品
        //物品的参数
        public int value1 = 0;
        public int value2 = 0;
        public int value3 = 0;
        public int value4 = 0;
        public int value5 = 0;
        public int cost = 100;   //物品的花费

        //初始化设置物品
        public void Set(string name, string description, string bitmap_path, int isdepletion, int value1, int value2, int value3, int value4, int value5)
        {
            this.name = name;
            this.description = description;
            if (bitmap_path != null && bitmap_path != "")
            {
                bitmap = new Bitmap(bitmap_path);
                bitmap.SetResolution(96, 96);
            }
            this.isdepletion = isdepletion;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
        }

        public delegate void Use_event(Weapon weapon);
        public event Use_event use_event;
        //使用物品
        public void Use()
        {
            if (num <= 0)
            {
                return;   //是否拥有该物品
            }
            if (isdepletion != 0)
            {
                num--;   //是否为消耗品
            }
            use_event?.Invoke(this);//使用事件
        }
        //增加物品
        public static void Add_item(int index, int num)
        {
            if (weapons == null)
            {
                return;                //处理异常
            }
            if (index < 0)
            {
                return;
            }
            if (weapons[index] == null)
            {
                return;
            }
            weapons[index].num += num;   //数量增减
            if (weapons[index].num < 0)  //异常数值处理
            {
                weapons[index].num = 0;
            }
        }
        //添加hp,使用value1
        public static void Add_hp(Weapon weapon)
        {
            Player player = Form1.players[select_player];   //当前选择的角色
            player.hp += weapon.value1;
            if (player.hp > player.max_hp)
            {
                player.hp = player.max_hp;
            }
            if (player.hp < 0)
            {
                player.hp = 0;
            }
        }
        //增加mp,使用value2
        public static void Add_mp(Weapon weapon)
        {
            Player player = Form1.players[select_player];   //当前选择的角色
            player.mp += weapon.value1;
            if (player.mp > player.max_mp)
            {
                player.mp = player.max_mp;
            }
            if (player.mp < 0)
            {
                player.mp = 0;
            }
        }
        /*
         * 对于武器  value的定义  
         * value1 装备的类型 1表示武器  2表示防具
         * value2 攻击加成
         * value3 防御加成
         * value4 速度加成
         * value5 运气加成
         */
        /// <summary>
        /// 卸载武器
        /// </summary>
        /// <param name="type"></param>
        public static void Unequip(int type)
        {
            //获取index
            int index;
            if (type == 1)
            {
                index = Form1.players[select_player].equip_att;
                Form1.players[select_player].equip_att = -1;
            }
            else if (type == 2)
            {
                index = Form1.players[select_player].equip_def;
                Form1.players[select_player].equip_def = -1;
            }
            else
            {
                return;
            }
            if (weapons == null)
            {
                return;
            }
            if (index < 0)
            {
                return;
            }
            if (index >= weapons.Length)
            {
                return;
            }
            if (weapons[index] == null)
            {
                return;
            }
            Add_item(index, 1);
        }
        public static void Equip(Weapon weapon)
        {
            if (weapons == null)
            {
                return;
            }
            if (weapon == null)
            {
                return;
            }
            int index = -1;
            for (int i = 0; i < weapons.Length; i++)  //遍历物品找到装备id
            {
                if (weapons[i] == null)
                {
                    continue;
                }
                if (weapon.name == weapons[i].name && weapon.description == weapons[i].description)
                {
                    index = i;   //找到了
                    break;
                }
            }
            if (index < 0)
            {
                return;
            }
            if (index >weapons.Length)
            {
                return;
            }
            if (weapons[index] == null)
            {
                return;
            }

            Unequip(weapon.value1);  //卸载装备

            if (weapon.value1 == 1)
            {
                Form1.players[select_player].equip_att = index;
            }
            else if (weapon.value1 == 2)
            {
                Form1.players[select_player].equip_def = index;
            }
            else
            {
                return;
            }
        }
        public static void Ipybook(Weapon weapon)
        {
            Message.Show("", "传说世界混沌的之际，虚实相照，融为一体。几万年过去，粒子稳定，世界渐渐真实，人们早已忘记曾经的虚幻。但烟花璀璨，也不过一时之闪耀，再真实也抵不过时间之茫茫。", "", Message.Face.LEFT);
            Task.Block();
            Message.Show("", "传说本书，如剑锋利，可开创一片虚幻世界，世人争抢，刀兵不断。为了世界和平，作者将本书藏于山中，只待有缘人。", "", Message.Face.LEFT);
            Task.Block();
        }
    }

     class Attack : Weapon
     {
       
     }

    class Defense : Weapon
    {

    }
}

