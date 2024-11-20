using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson3;
using 贪吃蛇.Lesson4;
using 贪吃蛇.Lesson5;

namespace 贪吃蛇.Lesson6
{
    /// <summary>
    /// 蛇的移动方向
    /// </summary>
    enum E_MoveDir
    {
        Up,
        Down,
        Left,
        Right,
    }

    class Snake : IDraw
    {
        SnakeBody[] bodys;
        //记录当前蛇的长度
        int nowNum;
        //当前移动方向
        E_MoveDir dir;

        public Snake(int x, int y)
        {
            //粗暴的方法 直接申明200个空间 来装蛇身体的数组
            bodys = new SnakeBody[200];

            bodys[0] = new SnakeBody(E_SnakeBody_Type.Head, x, y);
            nowNum = 1;

            dir = E_MoveDir.Down;
        }

        public void Draw()
        {
            //画一节一节的身子
            for (int i = 0; i < nowNum; i++)
            {
                bodys[i].Draw();
            }
        }

        #region Lesson7 蛇的移动
        public void Move()
        {
            //移动前
            //擦除最后一个位置
            Console.SetCursorPosition(bodys[nowNum - 1].pos.x, bodys[nowNum - 1].pos.y);
            Console.WriteLine("  ");

            //在蛇头移动之前 从蛇尾开始 不停的 让后一个的位置 等于前一个位置
            //注意执行到这里时，最后一个位位置已经被擦除，不用担心会被打印出来
            for (int i = nowNum - 1; i > 0; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }

            //再移动
            switch (dir)
            {
                case E_MoveDir.Up:
                    --bodys[0].pos.y;
                    break;
                case E_MoveDir.Down:
                    ++bodys[0].pos.y;
                    break;
                case E_MoveDir.Left:
                    bodys[0].pos.x -= 2;
                    break;
                case E_MoveDir.Right:
                    bodys[0].pos.x += 2;
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region Lesson8 改变方向
        public void ChangeDir(E_MoveDir dir)
        {
            //只有头部的时候 可以直接左转右 右转左 上转下 下转上
            //有身体时 这些情况就不能直接转
            if (this.dir == dir || 
                nowNum > 1 && 
                (this.dir == E_MoveDir.Up && dir == E_MoveDir.Down || 
                this.dir == E_MoveDir.Down && dir == E_MoveDir.Up || 
                this.dir == E_MoveDir.Left && dir == E_MoveDir.Right || 
                this.dir == E_MoveDir.Right && dir == E_MoveDir.Left))
            {
                return;
            }

            //只要没有 return 就记录外面传入的方向 之后就会按照这个方向去移动
            this.dir = dir;
        }
        #endregion

        #region Lesson9 撞墙撞身体结束逻辑
        public bool CheckEnd(Map map)
        {
            for (int i = 0; i < map.walls.Length; i++)
            {
                if (bodys[0].pos == map.walls[i].pos)
                {
                    return true;
                }
            }

            for (int i = 1; i < nowNum; i++)
            {
                if (bodys[0].pos == bodys[i].pos)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Lesson10 吃食物相关
        //通过传入一个位置 来判断这个位置 是否和蛇重合
        public bool CheckSamePos(Position p)
        {
            for (int i = 0; i < nowNum; i++)
            {
                if (p == bodys[i].pos)
                {
                    return true;
                }
            }
            return false;
        }

        //蛇吃食物
        public void CheckEatFood(Food food)
        {
            for (int i = 0; i < nowNum; i++)
            {
                if (food.pos == bodys[0].pos)
                {
                    //说明吃到了 就应该让食物 位置刷新一下 再增加蛇的长度
                    food.RandomPos(this);
                    //长身体
                    AddBody();
                }
            }
        }

        #endregion

        #region Lesson11 长身体
        public void AddBody()
        {
            SnakeBody frontBody = bodys[nowNum - 1];
            //先长
            bodys[nowNum] = new SnakeBody(E_SnakeBody_Type.Body, frontBody.pos.x, frontBody.pos.y);
            //再加长度
            ++nowNum;
        }
        #endregion

    }
}
