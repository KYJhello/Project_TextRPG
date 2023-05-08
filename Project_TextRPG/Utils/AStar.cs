using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class AStar
    {
        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Vector2[] Direction =
        {
            new Vector2(  0, +1 ),			// 상
			new Vector2(  0, -1 ),			// 하
			new Vector2( -1,  0 ),			// 좌
			new Vector2( +1,  0 ), 			// 우
			new Vector2( -1, +1 ),		    // 좌상
			new Vector2( -1, -1 ),		    // 좌하
			new Vector2( +1, +1 ),		    // 우상
			new Vector2( +1, -1 )		    // 우하
		};

        public static bool PathFinding(Tile[,] tileMap, Vector2 start,
            Vector2 end, out List<Vector2> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            bool[,] visited = new bool[ySize, xSize];
            ASNode[,] nodes = new ASNode[ySize, xSize];

            // 가장낮은 정점을 뺴오기 위해 우선순위 큐를 사용
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            // f값이 같은경우 g와 h값을 비교하는 구조체를 써주면 좋다
            // f랑 g를 같이 가지고 있는 구조체를 사용하기
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문 표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    Vector2? pathPoint = end;
                    path = new List<Vector2>();

                    while (pathPoint != null)
                    {
                        Vector2 point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();
                    return true;
                }
                // 4. AStar 탐색을 진행
                // 방향 탐색
                // 상->하->좌->우
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] != Tile.tile)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;
                    // 대각선 이동시 대각선 좌우가 막혀있는 경우
                    else if (4 <= i && i <= 7)
                    {
                        if (tileMap[y - Direction[i].y, x] == Tile.wall && tileMap[y, x - Direction[i].x] == Tile.wall)
                        {
                            continue;
                        }
                    }

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Vector2(x, y), end);
                    ASNode newNode = new ASNode(new Vector2(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 점수계산이 되지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 더 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }

        // 휴리스틱(Heyristic) : 최상의 경로를 추정하는 순위값,
        //                      휴리스틱에 의해 경로탐색 효율이 결정
        private static int Heuristic(Vector2 start, Vector2 end)
        {
            int xSize = Math.Abs(start.x - end.x);
            int ySize = Math.Abs(start.y - end.y);

            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        private class ASNode
        {
            public Vector2 point;     // 현재 정점 위치
            public Vector2? parent;   // 이 정점을 탐색한 정점

            public int f;           // f(x) = g(x) + h(x) : 총거리
            public int g;           // 현재까지의 거리, 즉 지금까지 경로 가중치
            public int h;           // 휴리스틱 : 앞으로 예상되는 거리, 목표까지 추정경로 가중치

            public ASNode(Vector2 point, Vector2? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }
}
