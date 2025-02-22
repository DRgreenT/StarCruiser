
class UserInput
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
            range = Program.player.posX - range < 0 || Program.player.posX + range > windowSizeX - 3 ? 1 : range;
            // Clear the old player position
            Draw.SetCursorAndWrite(Program.player.posX, windowSizeY - 1, "  ");

            // Handle movement
            if (key == ConsoleKey.LeftArrow && Program.player.posX > 1)
            {
                Program.player.posX = Program.player.posX - range;
            }
            if (key == ConsoleKey.RightArrow && Program.player.posX < windowSizeX - 3)
            {
                Program.player.posX = Program.player.posX + range;
            }

            // Handle shooting (Spacebar or Shift + Arrow)
            if (key == ConsoleKey.Spacebar)
            {
                Program.projectils.Add(GameObject.CreateNewObject(Program.player.posX, Program.player.posY - 1));
            }
        }
    }
}

