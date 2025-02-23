public class GameObject
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public bool isPlayer { get; set; }
    public bool hasCollison { get; set; }
    public int scoreValue { get; set; }
    public int hitBoxSize { get; set; }
    public int moveSpeed { get; set; }

    public string grafix = "";
    public static List<GameObject> CreateList()
    {
        return new List<GameObject>();
    }

    public static GameObject CreateNewObject(string grafix, int xPos, int yPos,int hitBoxSize, bool isPlayer = false, bool hasCollision = true, int scoreVal = 0, int moveSpeed = 1)
    {
        GameObject newObject = new GameObject
        {
            grafix = grafix,
            xPos = xPos,
            yPos = yPos,
            hitBoxSize = hitBoxSize,
            isPlayer = isPlayer,
            hasCollison = hasCollision,
            scoreValue = scoreVal,
            moveSpeed = moveSpeed

        };
        return newObject;
    }
}