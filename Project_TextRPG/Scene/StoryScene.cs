using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class StoryScene : Scene
    {
        private int index = 0;
        public StoryScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine(Data.storys[index]);
            sb.AppendLine("1: 이전 내용");
            sb.AppendLine("2: 다음 내용");
            sb.Append(" : ");

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
                    if(index <= 0)
                    {
                        break;
                    }
                    Console.WriteLine(Data.storys[index--]);
                    break;
                case 2:
                    if (index >= Data.storys.Count -1)
                    {
                        game.Map();
                    }
                    Console.WriteLine(Data.storys[index++]);

                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
