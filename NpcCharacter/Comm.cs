using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpcCharacter
{
    public class Comm
    {
        public static long Time()
        {
            DateTime datetime = new DateTime(1970, 1, 1);
            TimeSpan timespan = DateTime.Now - datetime;
            return (long)timespan.TotalMilliseconds;
        }

        //定义枚举判断方向
        public enum Direction
        {
            UP=4,
            DOWN=1,
            RIGHT=3,
            LEFT=2,
        }
    }
}
