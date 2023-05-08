using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("######################");
            sb.AppendLine("##   도화가의모험   ##");
            sb.AppendLine("######################");

            sb.AppendLine("1:게임시작");
            sb.AppendLine("2:게임종료");
            sb.Append("메뉴를 선택하세요 : ");

            Console.WriteLine(sb);
        }

        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                // 1sec 기다리기
                Thread.Sleep(1000);
                return;
            }
            switch (command)
            {
                case 1:
                    game.GameStart();
                    break;
                case 2:
                    game.GameOver("게임을 종료했습니다.");
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
