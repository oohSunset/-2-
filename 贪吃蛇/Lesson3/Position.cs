using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.Lesson3
{
    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //贪吃蛇中 肯定存在 位置比较

        public static bool operator ==(Position p1, Position p2)
        {
            if(p1.x == p2.x && p1.y == p2.y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
            {
                return false;
            }
            return true;
        }

    }
}
