using System.Numerics;

class Position
{
    public static void UpdateStarPositions(List<GameObject> stars)
    {
        for (int i = stars.Count - 1; i >= 0; i--)
        {
            GameObject star = stars[i];
            Draw.SetCursorAndDraw(star.xPos, star.yPos);
            int[] playerPosStart = { Program.player.GetPosX(), Program.player.GetPosY()};
            int[] playerPosEnd = { Program.player.GetPosX() + Grafix.player.Length, Program.player.GetPosY() };
            star.yPos++;
            int[] starPos = { star.xPos, star.yPos };
            if (star.hasCollison && (playerPosStart.SequenceEqual(starPos) || playerPosEnd.SequenceEqual(starPos)))
            {
                Program.player.SetLives(Program.player.GetLives()-1);
                if (Program.player.GetLives() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("GameOver!!!");
                    Environment.Exit(0);
                }
            }
            if (star.yPos > Settings.windowSizeY - 1)
            {
                stars.RemoveAt(i);
            }
        }
    }
    public static void UpdateProjectilesPositions(List<GameObject> list, int speed = 100)
    {
        if (list.Count == 0)
        {
            Program.GameTick(speed);
            return;
        }
        
        for (int i = list.Count - 1; i >= 0; i--)
        {

            GameObject p = list[i];
            Draw.SetCursorAndDraw(p.xPos, p.yPos);
            if (p.isPlayer)
            {
                
                p.yPos--;
            }
            else
            {
                
                p.yPos++;
            }
            if (p.yPos < 5 || p.yPos > Settings.windowSizeY - 2)
            {
                list.Remove(p);
            }
        }
        Program.GameTick(speed);
    }
    public static void UpdateEnemyPosition(List<GameObject> enemies)
    {
        int windowSizeX = Settings.windowSizeX;

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemies[i];
            if (enemy.xPos + 3 < windowSizeX - 1 && enemy.xPos - 1 > 0)
            {
                switch (Program.timesUpdatePosX)
                {
                    case < 11:
                        Draw.SetCursorAndDraw(enemy.xPos, enemy.yPos, "   ");
                        enemy.xPos++;
                        break;

                    case int n when (n > 10 && n < 21):
                        Draw.SetCursorAndDraw(enemy.xPos, enemy.yPos, "   ");
                        enemy.xPos--;
                        break;

                    case 21:
                        Program.timesUpdatePosX = 0;
                        Program.timesUpdatePosY++;
                        break;
                }

                if (Program.timesUpdatePosY == 50)
                {
                    foreach (var en in enemies)
                    {
                        Draw.SetCursorAndDraw(en.xPos, en.yPos, "   ");
                        en.yPos++;
                    }
                    Program.timesUpdatePosY = 0;
                }
            }
            if (enemies[i].yPos == Settings.windowSizeY - 1)
            {
                enemies.Remove(enemy);
            }
        }
        Program.timesUpdatePosX++;
    }
}
