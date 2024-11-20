using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.Lesson3
{
    abstract class GameObject : IDraw
    {
        //游戏对象位置
        public Position pos;

        //可以继承接口后 把接口中的行为 编程 抽象行为
        public abstract void Draw();
    }
}
