
class Generator
{
    private static int totalEnemiesSpawned = 0;
    private static Random rand = new();
    static int GetRandomNumber(int min, int max)
    {
        return rand.Next(min, max);
    }
    public static void GenerateStars(List<GameObject> stars)
    {
        bool starHasCollison = false;
        int scoreValue = 0;
        int randGen = GetRandomNumber(0, 100);
        if (randGen > 80)
        {
            if (Program.starCount == 15)
            {
                starHasCollison = true;
                scoreValue = 10;
                Program.starCount = 0;
            }
            int randStarPosX = GetRandomNumber(2, Settings.windowSizeX - 3);
            if(starHasCollison)
            {
                GameObject star = GameObject.CreateNewObject(Grafix.blueStar, randStarPosX, Settings.gameFieldStartY, 1, false, starHasCollison, scoreValue);
                stars.Add(star);
            }
            else
            {
                GameObject star = GameObject.CreateNewObject(Grafix.star, randStarPosX, Settings.gameFieldStartY, 1, false, starHasCollison, scoreValue);
                stars.Add(star);
            }
            Program.starCount++;
        }
    }

    public static void GenerateEnemy(List<GameObject> enemies)
    {
        bool isStandardEnemie = true;
        if (totalEnemiesSpawned >= 20)
        {
            Program.maxEnemies++;
            totalEnemiesSpawned = 0;
            isStandardEnemie = false;
        }
        if (enemies.Count < Program.maxEnemies)
        {
            for (int i = enemies.Count; i < Program.maxEnemies; i++)
            {
                int randX = GetRandomNumber(20, Settings.windowSizeX - 20);
                bool isOccupied = false;
                for (int j = -3; j <= 3; j++)
                {
                    if (enemies.Any(obj => obj.xPos + j == randX))
                    {
                        isOccupied = true;
                        break;
                    }
                }
                if (!isOccupied)
                {
                    if(isStandardEnemie)
                    {
                        GameObject enemy = GameObject.CreateNewObject(Grafix.enemyS,randX, 7, 3, false, true, 1);
                        enemies.Add(enemy);
                    }
                    else
                    {
                        GameObject enemy = GameObject.CreateNewObject(Grafix.enemyP,randX, 7, 3, false, true, 10,2);
                        enemies.Add(enemy);
                    }
                        
                    totalEnemiesSpawned++;
                    break;
                }
            }
        }
    }
}

