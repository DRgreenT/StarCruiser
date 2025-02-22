class Program
{

    public static List<GameObject> projectils = new();
    public static List<GameObject> stars = new();
    public static List<GameObject> enemies = new();
    public static Player? player = new();

    public static int objectCounter = 0;
    public static int starCount = 0;

    public static int timesUpdatePosX = 0;
    public static int timesUpdatePosY = 0;
    static async Task Main()
    {

        await GameLoop(); // ✅ Await game so it doesn't exit immediately
        return;
    }



    static void Initialise()
    {
        File.Delete("debug.txt");

        player = Player.Create();
        player.posX = Settings.windowSizeX / 2;
        player.posY = Settings.windowSizeY - 1;
        player.lives = 5;

        projectils = GameObject.CreateList();
        stars = GameObject.CreateList();
        enemies = GameObject.CreateList();

        Settings.ConsoleSettings();

        Draw.Frame(Settings.windowSizeX, Settings.windowSizeY);
        Draw.Info();

        Draw.Player(player.posX, Settings.windowSizeY);
    }

    public static async Task GameLoop()
    {
        Initialise();
         
        while (true)
        {
            UserInput.HandleInput();
            UpdateGameObejects();
            SpawNewGameObjects();
            DrawGameObjects();
            System.Threading.Thread.Sleep(75);
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
        Draw.GameObjects(stars, Grafix.star, true);
        Draw.Player(player.posX, Settings.windowSizeY - 1);
        Draw.GameObjects(enemies, Grafix.enemy);
        Draw.GameObjects(projectils, Grafix.bullet);
    }

    private static async void UpdateGameObejects()
    {
        Position.UpdateStarPositions(stars);
        Position.UpdateEnemyPosition(enemies);
        await Task.Run(() => Position.UpdateProjectilesPositions(projectils, 500));
    }

    
    public static async Task GameTick(int timePerTick)
    {
        await Task.Delay(timePerTick);
    }



}

