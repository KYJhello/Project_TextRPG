using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_TextRPG
{
    public class Game
    {
        private bool isRunning = true;
        public Scene curScene { get; private set; }
        public MainMenuScene mainMenu { get; private set; }
        public MapScene mapScene { get; private set; }
        public InventoryScene inventoryScene { get; private set; }
        public BattleScene battleScene { get; private set; }
        public StoryScene storyScene { get; private set; }
        public void Run()
        {
            // 1. 초기화
            Init();
            //GameStart();

            // 2. 게임 루프
            while (isRunning)
            {
                // 3. 랜더링
                Render();

                // 5. 업데이트(갱신)
                Update();
            }
            // 6. 마무리(게임 끝내기)
            GameOver();
        }
        private void Init()
        {
            Console.CursorVisible = false;
            Data.Init();
            Data.player.SetPlayerGame(this);
            mainMenu = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);
            storyScene = new StoryScene(this);
            curScene = mainMenu;
        }
        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }
        private void Update()
        {
            curScene.Update();
        }
        public void MainMenu()
        {
            curScene = mainMenu;
        }
        public void Story()
        {
            curScene = storyScene;
        }
        public void Map()
        {
            curScene = mapScene;
        }
        public void Battle(Monster monster)
        {
            curScene = battleScene;
            battleScene.StartBattle(monster);
        }
        public void Inventory()
        {
            curScene = inventoryScene;
        }

        public void GameStart()
        {
            curScene = storyScene;
        }
        public void GameOver(string text = "")
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            sb.AppendLine();
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            isRunning = false;
        }
    }
}
