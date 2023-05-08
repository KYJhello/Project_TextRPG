using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class DemonLord : Monster
    {
        public DemonLord()
        {
            icon = '◈';
            name = "마왕";
            curHp = 1000;
            maxHp = 1000;
            ap = 500;
            dp = 100;
            shield = 5;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (엄청난 마왕  )  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }
        public override void MoveAction()
        {

        }
    }
}
