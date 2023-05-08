using System.Drawing;
using System;

namespace Project_TextRPG
{
    public static class Data
    {
        public static Player player;
        public static List<Monster> monsters;
        public static List<Item> items;
        public static Tile[,] map;
        public static List<string> storys;

        public static void Init()
        {
            player = new CheatBrave();
            monsters = new List<Monster>();
            items = new List<Item>();
            storys = new List<string>();

            // 스토리 초기화
            string sb1 = "스토리 1\r\n대충 왕도 RPG 도입부란 내용";
            string sb2 = "...중략...\r\n마을주민 : 도와줘요.";
            string sb3 = "마을주민 : 해줘 ";
            string sb4 = "마을주민 : 그냥 해줘";
            string sb5 = "마을주민 : 감사합니다.";

            storys.Add(sb1);
            storys.Add(sb2);
            storys.Add(sb3);
            storys.Add(sb4);
            storys.Add(sb5);
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
        public static void LoadLevel()
        {
            map = new Tile[,]
                {
                { Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.wall, Tile.tile, Tile.wall, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.tile, Tile.wall, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.wall, Tile.tile, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall, Tile.wall, Tile.tile, Tile.wall, Tile.wall, Tile.wall, Tile.wall },
                { Tile.wall, Tile.tile, Tile.wall, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.tile, Tile.wall },
                { Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall, Tile.wall }
                };
            player.pos = new Vector2(2, 2);

            monsters.Clear();
            items.Clear();

            Slime slime1 = new Slime();
            slime1.pos = new Vector2(3, 5);
            monsters.Add(slime1);

            Slime slime2 = new Slime();
            slime2.pos = new Vector2(7, 5);
            monsters.Add(slime2);

            Dragon dragon = new Dragon();
            dragon.pos = new Vector2(12, 12);
            monsters.Add(dragon);

            DemonLord demonLord = new DemonLord();
            demonLord.pos = new Vector2(3, 20);
            monsters.Add(demonLord);

            //Item potion = new Potion();
            //potion.pos = new Vector2(12, 1);
            //items.Add(potion);

            //Item largePotion = new LargePotion();
            //largePotion.pos = new Vector2(12, 2);
            //items.Add(largePotion);
        }
        public static void SetStorys()
        {

        }
    }
}
