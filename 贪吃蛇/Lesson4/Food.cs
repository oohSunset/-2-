using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson3;
using 贪吃蛇.Lesson6;

namespace 贪吃蛇.Lesson4
{
    class Food : GameObject
    {
        public Food(Snake snake)
        {
            RandomPos(snake);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¤");
        }

        //随机位置的行为 行为 和蛇的位置 有关系 有了蛇再来实现
        public void RandomPos(Snake snake)
        {
            //随机位置
            Random r = new Random();
            int x = r.Next(2, 38) * 2;
            int y = r.Next(1, 18);
            pos = new Position(x, y);
            //判断是否和蛇的位置重合
            if (snake.CheckSamePos(pos))
            {
                RandomPos(snake);
            }
        }

    }
}
