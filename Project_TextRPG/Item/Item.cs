using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Item
    {
        protected bool isBattleItem = false;
        public string name { get; protected set; }
        public string description { get; protected set; }
        public int weight { get; protected set; }
        public char icon = '★';
        public Vector2 pos;

        public abstract void Use(Game game);
    }
}
