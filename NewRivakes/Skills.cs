using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRivakes
{
    public class Skills
    {
        public static Skills[] skills;
        public string name = "";
        public string description = "";
        public int MP;
        public int type;   //表示技能的类型：用于自身还是用于自己

        public void Set(string name,string description,int mp)
        {
            this.name = name;
            this.description = description;
            this.MP = mp; 
        }


        //使用  定义委托类型
        public delegate void Use_event(Skills skill);
        public event Use_event use_event;
        public void Use(Protagonist protagonist)
        {
            if (protagonist.Mp < MP)  //mp判断
                return;
            protagonist.Mp -= MP ;   //减去mp
            if (use_event != null)
                use_event(this);   //使用技能
        }
    }
}
