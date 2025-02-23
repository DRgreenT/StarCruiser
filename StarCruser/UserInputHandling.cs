public class UserInput
{
    public static void HandleInput()
    {
        int windowSizeX = Settings.windowSizeX;
        int windowSizeY = Settings.windowSizeY;

        while (Console.KeyAvailable) // Check for multiple key inputs
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            bool isShiftPressed = (keyInfo.Modifiers & ConsoleModifiers.Shift) != 0;
            int range = isShiftPressed ? 5 : 1;
            if(Program.player.GetPosX() - range < 0 || Program.player.GetPosX() + range > windowSizeX - 3)
            {
                range = 1;
            }
           
            // Handle movement
            if (key == ConsoleKey.LeftArrow && Program.player.GetPosX() > 1)
            {
                Draw.SetCursorAndDraw(Program.player.GetPosX(), windowSizeY - 1, "  ");
                Program.player.SetPosX(Program.player.GetPosX() - range);
            }
            if (key == ConsoleKey.RightArrow && Program.player.GetPosX() < windowSizeX - 3)
            {
                Draw.SetCursorAndDraw(Program.player.GetPosX(), windowSizeY - 1, "  ");
                Program.player.SetPosX(Program.player.GetPosX() + range);
            }

            // Handle shooting (Spacebar or Shift + Arrow)
            if (key == ConsoleKey.Spacebar)
            {
                GameObject p = GameObject.CreateNewObject(Grafix.bullet, Program.player.GetPosX(), Program.player.GetPosY() - 1,1,true);
                Program.projectils.Add(p);
            }
        }
    }
}

