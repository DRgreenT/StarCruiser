public class Settings
{
    public static readonly int windowSizeX = 120;
    public static readonly int windowSizeY = 30;
    public static readonly int gameFieldStartY = 7;
    public static int playerPosition = 0;
    public static decimal gameSpeed = 75;
    public static decimal gameSpeedMultiplier = 1;

    public static bool isDebugMode = true;

    public static void ResetWindowSize()
    {
        new Thread(() =>
        {
            while (true) // Endlosschleife für permanente Überwachung
            {
                if (Console.WindowWidth != windowSizeX || Console.WindowHeight != windowSizeY)
                {
                    Console.SetWindowSize(windowSizeX, windowSizeY);
                }
                Thread.Sleep(100); // Verhindert CPU-Überlastung (alle 0,5 Sek. prüfen)
            }
        })
        { IsBackground = true }.Start(); // Startet den Thread im Hintergrund
    }

    public static void ConsoleSettings(bool cursorIsVisible = false)
    {
        Console.CursorVisible = cursorIsVisible;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.SetWindowSize(windowSizeX, windowSizeY);
    }
}

