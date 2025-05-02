using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StarCruiser
{
    class Program
    {

        public static List<GameObject> projectils = new List<GameObject>();
        public static List<GameObject> stars = new List<GameObject>();
        public static List<GameObject> enemies = new List<GameObject>();
        public static List<Explosion> explosions = new List<Explosion>();
        public static Player player;

        public static int objectCounter = 0;
        public static int starCount = 0;

        public static int maxEnemies = 4;
        public static int gameSpeedAdj = 0;

        public static bool isRunning = true;
        static void Main()
        {
            Console.CursorVisible = false;
            GameLoop();
            Console.CursorVisible = true;
            return;
        }

        static void Initialise()
        {
            File.Delete("debug.txt");

            player = new Player();
            player.SetPosX(Settings.windowSizeX / 2);
            player.SetPosY(Settings.windowSizeY - 1);
            player.SetLives(5);

            projectils = GameObject.CreateList();
            stars = GameObject.CreateList();
            enemies = GameObject.CreateList();

            Settings.ConsoleSettings();


            Draw.Frame(Settings.windowSizeX, Settings.windowSizeY);
            Draw.Info();

            Draw.Player(player.GetPosX(), player.GetPosY());
        }

        public static void GameLoop()
        {
            Initialise();
            while (isRunning)
            {

                objectCounter = stars.Count + enemies.Count + projectils.Count + 1;
                UserInput.HandleInput();
                UpdateGameObejects();
                SpawNewGameObjects();
                DrawGameObjects();
                System.Threading.Thread.Sleep(75 - gameSpeedAdj);
            }
        }

        private static void SpawNewGameObjects()
        {
            Generator.GenerateStars(stars);
            Generator.GenerateEnemy(enemies);
        }

        private static void DrawGameObjects()
        {
            Draw.Info();
            Draw.GameObjects(stars, true);
            Draw.Player(player.GetPosX(), player.GetPosY());
            Draw.GameObjects(enemies);
            Draw.GameObjects(projectils);
            Draw.Explosion();
        }

        private static void UpdateGameObejects()
        {
            Position.UpdateStarPositions(stars);
            Position.UpdateEnemyPosition(enemies);
            Position.UpdateProjectilesPositions(projectils);
            Position.CheckProjectilesCollision(stars);
            Position.CheckProjectilesCollision(enemies);
        }

        public static async Task GameTick(int timePerTick)
        {
            await Task.Delay(timePerTick);
        }
    }
}


