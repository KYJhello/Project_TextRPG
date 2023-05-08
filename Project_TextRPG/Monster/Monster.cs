using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Monster
    {
        public string name;
        public char icon = '▼';
        public Vector2 pos;

        public string image;
        public int curHp;
        public int maxHp;
        public int ap;
        public int dp;
        public int? shield = 0;
        // 상속받은 개체에서 오버라이드할 함수
        public abstract void MoveAction();
        public void Move(Direction dir)
        {
            Vector2 prevPos = pos;
            // 플레이어 이동
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
                case Direction.LeftUp:
                    pos.y--;
                    pos.x--;
                    break;
                case Direction.LeftDown:
                    pos.y++;
                    pos.x--;
                    break;
                case Direction.RightUP:
                    pos.y--;
                    pos.x++;
                    break;
                case Direction.RightDown:
                    pos.y++;
                    pos.x++;
                    break;
            }

            // 이동한 자리가 벽일 경우
            if (Data.map[pos.y, pos.x] == Tile.wall)
            {
                // 원위치 시키기
                pos = prevPos;
            }
        }
        public void TakeDamage(int damage)
        {
            if (shield-- > 0)
            {
                Console.WriteLine($"{name}(은/는) 실드가 {shield} 회 남았다.");
                return;
            }
            if (damage > dp)
            {
                Console.WriteLine($"{name}(은/는) {damage - dp} 데미지를 받았다.");
                curHp -= damage - dp;
            }
            else
                Console.WriteLine($"공격은 {name}에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (curHp <= 0)
            {
                Console.WriteLine($"{name}(은/는) 쓰려졌다!");
                Thread.Sleep(1000);
                //Console.WriteLine("몬스터는 포션을 떨어뜨렸다!");
                //Data.player.GetItem(new Potion());
                //Thread.Sleep(1000);
            }
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{name}(이/가) 플레이어를 공격합니다.");
            Thread.Sleep(1000);
            player.TakeDamage(ap);
        }
    }
}
