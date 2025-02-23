using System;
using System.Numerics;

class Position
{
    static int[] playerPosStart = { 0, 0 };
    static int[] playerPosEnd = { 0, 0 };

    static void GetPlayerPosition()
    {
        playerPosStart[0] = Program.player.GetPosX();
        playerPosStart[1] = Program.player.GetPosY();
        playerPosEnd[0] = Program.player.GetPosX() + 1;
        playerPosEnd[1] = Program.player.GetPosY();
    }

    static void UpdateLives()
    {
        Program.player.SetLives(Program.player.GetLives() - 1);
        if (Program.player.GetLives() == 0)
        {
            Console.Clear();
            Console.WriteLine("GameOver!!!");
            Program.isRunning = false;
        }
    }
    public static void UpdateStarPositions(List<GameObject> stars)
    {
        GetPlayerPosition();
        for (int i = stars.Count - 1; i >= 0; i--)
        {
            GameObject star = stars[i];
            Draw.SetCursorAndDraw(star.xPos, star.yPos);

            star.yPos++;
            int[] starPos = { star.xPos, star.yPos };
            if (star.hasCollison && (playerPosStart.SequenceEqual(starPos) || playerPosEnd.SequenceEqual(starPos)))
            {
                UpdateLives();
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
    static int repositionCounterX = 0;
    static int repositionCounterY = 0;
    static bool moveLeft = false;

    public static bool IsProjectilHit(GameObject gameObject, GameObject projectil, int hitBoxSize)
    {
        return projectil.yPos == gameObject.yPos && Math.Abs(projectil.xPos - gameObject.xPos) <= hitBoxSize;
    }

    public static void CheckProjectilesCollision(List<GameObject> gameObjects)
    {
        for(int i = gameObjects.Count - 1; i >= 0; i--)
        {
            GameObject gameObject = gameObjects[i];
            if (gameObject.hasCollison)
            {
                foreach (GameObject p in Program.projectils)
                {
                    if (IsProjectilHit(gameObject, p, gameObject.hitBoxSize))
                    {
                        gameObjects.RemoveAt(i);
                        Program.player.SetScore(Program.player.GetScore() + gameObject.scoreValue);
                    }
                }
            }
        }


    }
    public static void UpdateEnemyPosition(List<GameObject> enemies)
    {
        int windowSizeX = Settings.windowSizeX;

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemies[i];
            
            if (repositionCounterX >= enemies.Count * 20)
            {
                moveLeft = !moveLeft;
                repositionCounterX = 0;
                repositionCounterY++;
            }
            if (!moveLeft)
            {
                if (enemy.xPos + 3 < windowSizeX - 2)
                {
                    Draw.SetCursorAndDraw(enemy.xPos, enemy.yPos, "   ");
                    enemy.xPos += enemy.moveSpeed;
                    repositionCounterX++;
                }
                else
                {
                    Draw.SetCursorAndDraw(enemy.xPos, enemy.yPos, "   ");
                    enemy.xPos = 2;
                    repositionCounterX++;
                }
            }
            else
            {
                if (enemy.xPos - 3 >  2)
                {
                    Draw.SetCursorAndDraw(enemy.xPos, enemy.yPos, "   ");
                    enemy.xPos -= enemy.moveSpeed;
                    repositionCounterX++;
                }
                else
                {
                    Draw.SetCursorAndDraw(enemy.xPos, enemy.yPos, "   ");
                    enemy.xPos = windowSizeX - 4;
                    repositionCounterX++;
                }
            }
            if(repositionCounterY == 1)
            {
                foreach(var en in enemies)
                {
                    Draw.SetCursorAndDraw(en.xPos, en.yPos, "   ");
                    en.yPos += en.moveSpeed; 
                }
                repositionCounterY = 0;
            }
            if (enemies[i].yPos == Settings.windowSizeY - 1)
            {
                enemies.Remove(enemy);
                UpdateLives();

            }
        }

    }
}
