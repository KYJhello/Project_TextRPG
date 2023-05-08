using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public static class Data
    {
        public static Player player;
        public static List<Monster> monsters;
        public static List<Item> items;
        public static Tile[,] map;
        public static List<StringBuilder> storys;

        public static void Init()
        {
            player = new Player();
            monsters = new List<Monster>();
            items = new List<Item>();
        }
        public static bool IsObjectInPos(Vector2 pos)
        {
            return MonsterInPos(pos) == null && ItemInPos(pos) == null;
        }
        public static Monster MonsterInPos(Vector2 pos)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.pos.x == pos.x &&
                    monster.pos.y == pos.y)
                {
                    return monster;
                }
            }
            return null;
        }
        public static Item ItemInPos(Vector2 pos)
        {
            foreach (Item item in items)
            {
                if (item.pos.x == pos.x &&
                    item.pos.y == pos.y)
                {
                    return item;
                }
            }
            return null;
        }
        public static void LoadStory()
        {
            StringBuilder sb = new StringBuilder();

        }
    }
}
