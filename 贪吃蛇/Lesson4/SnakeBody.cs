﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson3;

namespace 贪吃蛇.Lesson4
{
    /// <summary>
    /// 蛇身体类型
    /// </summary>
    enum E_SnakeBody_Type
    {
        /// <summary>
        /// 蛇头
        /// </summary>
        Head,
        /// <summary>
        /// 蛇身
        /// </summary>
        Body,
    }

    class SnakeBody : GameObject
    {
        private E_SnakeBody_Type type;

        public SnakeBody(E_SnakeBody_Type type, int x, int y)
        {
            this.type = type;
            this.pos = new Position(x, y);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = type == E_SnakeBody_Type.Head ? 
                ConsoleColor.Yellow : ConsoleColor.Green;
            Console.WriteLine(type == E_SnakeBody_Type.Head ? "●" : "◎");
        }
    }
}
