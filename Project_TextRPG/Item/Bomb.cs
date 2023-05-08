using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Bomb : Item
    {
        protected Game game;
        private int damage = 10;
        public Bomb()
        {
            isBattleItem = true;

        }
        public override void Use(Game game)
        {
            this.game = game;
            if(game.curScene == game.battleScene &&
                isBattleItem)
            {
                BattleUse(game);
            }
            else
            {
                InventoryUse();
            }
        }
        public void InventoryUse()
        {
            if (isBattleItem)
            {
                Console.WriteLine("해당 아이템은 베틀에서만 사용가능합니다!");
                return;
            }
        }
        public void BattleUse(Game game)
        {
            game.battleScene.monster.TakeDamage(damage);
        }
    }
}
