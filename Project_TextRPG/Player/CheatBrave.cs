using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class CheatBrave : Player
    {
        public CheatBrave()
        {
            CurHp = int.MaxValue/2;
            MaxHp = int.MaxValue/2;
            CurDp = int.MaxValue/2;
            Level = 100;
            CurExp = 100;
            MaxExp = 101;
            AP = int.MaxValue/2;
            DP = int.MaxValue/2;

            skills = new List<Skill>();
            skills.Add(new Skill("공격하기", Attack));
            skills.Add(new Skill("회복하기", Recovery));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (  치트용사   )  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }
    }
}
