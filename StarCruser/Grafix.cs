public class Grafix
{
    public static readonly string bullet = Color.Yellow("|");
    public static readonly string player = Color.Green(@"/\");
    public static readonly string enemy = Color.Red("-o-");
    public static readonly string star = ".";
    public static readonly string blueStar = Color.Blue("*");

    public static int frameCounter = 0;


}

public class Draw
{
    public static void SetCursorAndDraw(int x, int y, string str = " ", bool isDebug = true)
    {
        try
        {
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }
        catch (Exception ex)
        {
            if (isDebug)
            {
                File.AppendAllText("debug.txt",
                    DateTime.Now.ToString() +
                    ": X:" + x.ToString().PadLeft(3, '0') +
                    " Y:" + y.ToString().PadLeft(3, '0') +
                    " Content: " + str +
                    "\n" + ex.Message + "\n");
            }
        }
    }

    public static void GameObjects(List<GameObject> gameObjects, string grafix, bool isStar = false)
    {
        if (!isStar)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SetCursorAndDraw(gameObjects[i].xPos, gameObjects[i].yPos, grafix);
            }
        }
        else
        {
            foreach (var star in gameObjects)
            {
                if (!star.hasCollison)
                {
                    SetCursorAndDraw(star.xPos, star.yPos, Grafix.star);
                }                    
                else
                {
                    SetCursorAndDraw(star.xPos, star.yPos, Grafix.blueStar);
                }
                    
            }
        }

    }
    public static void Player(int xPos, int yPos)
    {
        SetCursorAndDraw(xPos, yPos, Grafix.player);
    }
    public static void Frame(int windowSizeX, int windowSizeY, char horizontalGfx = '_', char verticalGfx = '#')
    {
        Console.SetCursorPosition(1, 4);
        for (int i = 0; i < windowSizeX; i++)
        {
            Console.Write(horizontalGfx);
        }
        for (int y = 0; y < windowSizeY; y++)
        {
            for (int x = 0; x < windowSizeX; x++)
            {
                if (x == 0 || x == windowSizeX - 1)
                {
                    SetCursorAndDraw(x, y, verticalGfx.ToString()); ;
                }
            }
        }
    }
    public static void Info(bool isDebug = true)
    {
        int windowSizeX = Settings.windowSizeX;

        string scoreStr = $"Score: " + Program.player.GetScore().ToString().PadLeft(5, '0');
        SetCursorAndDraw(5, 1, scoreStr);

        string levelStr = $"Level:    " + Program.player.GetLevel().ToString().PadLeft(2, '0');
        SetCursorAndDraw(5, 3, levelStr);

        string live = Color.Red("¤ ");
        string totallives = "Lives: ";

        for (int i = 0; i < Program.player.GetLives(); i++)
        {
            totallives += live;
        }
        // for (int i = 0; i < 15; i++)
        {
            SetCursorAndDraw(windowSizeX - i, 3);
        }
        SetCursorAndDraw(windowSizeX - 20, 3, totallives);

        if (isDebug)
        {
            // Debug:
            Grafix.frameCounter++;
            string debug = $"Frame: " + Grafix.frameCounter.ToString().PadLeft(5, '0') + " ObejctsCount: " + Program.objectCounter.ToString().PadLeft(3, '0');
            //SetCursorAndWrite(windowSizeX - 20, 1, debug);
            SetCursorAndDraw(5, 0, debug + "   starCount/starsOnScreen: " + Program.starCount.ToString().PadLeft(3, '0') + "/" + Program.stars.Count.ToString().PadLeft(2, '0'));
        }
    }

}