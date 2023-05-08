using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public enum Direction { Left, Right, Up, Down, LeftUp, LeftDown, RightUP, RightDown}
    public enum Tile { none, tile, wall}
}
