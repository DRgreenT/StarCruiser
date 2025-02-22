
class Generator
{

    public static void GenerateStars(List<GameObject> stars)
    {
        bool starHasCollison = false;

        Random randX = new();
        int randGen = randX.Next(0, 100);
        if (randGen > 80)
        {
            if (Program.starCount == 1)
            {
                starHasCollison = true;
                Program.starCount = 0;
            }
            int randStarX = randX.Next(2, Settings.windowSizeX - 3);
            GameObject star = GameObject.CreateNewObject(randStarX, Settings.gameFieldStartY, false, starHasCollison);
            stars.Add(star);
            Program.starCount++;
        }
    }

    public static void GenerateEnemy(List<GameObject> enemies)
    {
        Random rand = new();
        int randX = rand.Next(20, Settings.windowSizeX - 20);
        if (enemies.Count < 4)
        {
            if (enemies.Count == 0)
            {
                GameObject enemy = GameObject.CreateNewObject(randX, 7);
                if (!enemies.Contains(enemy))
                {
                    enemies.Add(enemy);
                }
            }
            else if (enemies.Count > 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    var en = enemies[i];
                    if (en.xPos + 3 > randX || en.xPos - 3 < randX)
                    {
                        GameObject enemy = GameObject.CreateNewObject(randX, 7);

                        if (!enemies.Contains(enemy))
                        {
                            enemies.Add(enemy);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
    }
}

