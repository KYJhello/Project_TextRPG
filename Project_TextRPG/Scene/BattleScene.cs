using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    
    public class BattleScene : Scene
    {
        public Monster monster;
        public BattleScene(Game game) : base(game)
        {
        }

        
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{monster.name}    {monster.curHp,3}/{monster.maxHp,3}");
            if (monster.shield >= 0)
            {
                Console.WriteLine($"보유 실드 횟수 : {monster.shield}");
            }
            Console.WriteLine();
            Console.WriteLine(monster.image);
            Console.WriteLine();
            Console.WriteLine(Data.player.image);
            Console.WriteLine();
            Console.WriteLine($"플레이어    {Data.player.CurHp,3}/{Data.player.MaxHp}");
            Console.WriteLine();

            for (int i = 0; i < Data.player.skills.Count; i++)
            {
                Console.Write($"{i + 1,2}. {Data.player.skills[i].name} ");
            }
            Console.WriteLine();
            Console.Write("명령을 입력하세요 : ");

            string input = Console.ReadLine();
        }

        public override void Update()
        {

        }
        public void StartBattle(Monster monster)
        {

        }

    }
}
