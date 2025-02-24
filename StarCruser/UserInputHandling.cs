public class UserInput
{
    public static void HandleInput()
    {
        int windowSizeX = Settings.windowSizeX;
        int windowSizeY = Settings.windowSizeY;

        while (Console.KeyAvailable) // Check for multiple key inputs
        {
            HashSet<ConsoleKey> detectedKey = new HashSet<ConsoleKey>();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            detectedKey.Add(key);
            bool isShiftPressed = (keyInfo.Modifiers & ConsoleModifiers.Shift) != 0;
            int range = isShiftPressed ? 5 : 1;
            if (Program.player.GetPosX() - range < 0 || Program.player.GetPosX() + range > windowSizeX - 3)
            {
                range = 1;
            }

            // Handle movement
            if (detectedKey.Contains(ConsoleKey.LeftArrow) && Program.player.GetPosX() > 1)
            {
                Draw.SetCursorAndDraw(Program.player.GetPosX(), windowSizeY - 1, "  ");
                Program.player.SetPosX(Program.player.GetPosX() - range);
            }
            if (detectedKey.Contains(ConsoleKey.RightArrow) && Program.player.GetPosX() < windowSizeX - 3)
            {
                Draw.SetCursorAndDraw(Program.player.GetPosX(), windowSizeY - 1, "  ");
                Program.player.SetPosX(Program.player.GetPosX() + range);
            }

            // Handle shooting (Spacebar or Shift + Arrow)
            if (detectedKey.Contains(ConsoleKey.Spacebar))
            {
                GameObject p = GameObject.CreateNewObject(Grafix.bullet, Program.player.GetPosX(), Program.player.GetPosY() - 1, 1, true);
                Program.projectils.Add(p);
            }
        }

    }
}


