using System;

namespace GoodsAndSkills
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

        //取反方向的方法
        public static Direction Opposite_direction(Direction direction)
        {
            if (direction == Direction.UP)
                return Direction.DOWN;
            else if (direction == Direction.DOWN)
                return Direction.UP;
            else if (direction == Direction.RIGHT)
                return Direction.LEFT;
            else if (direction == Direction.LEFT)
                return Direction.RIGHT;
            return Direction.DOWN;
        }
    }
}
