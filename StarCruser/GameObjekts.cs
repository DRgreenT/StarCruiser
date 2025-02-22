public class GameObject
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public bool isPlayer { get; set; }
    public bool hasCollison { get; set; }
    public static List<GameObject> CreateList()
    {
        return new List<GameObject>();
    }

    public static GameObject CreateNewObject(int xPos, int yPos, bool isPlayer = false, bool hasCollision = true)
    {
        GameObject newObject = new GameObject
        {
            xPos = yPos,
            yPos = xPos,
            isPlayer = isPlayer,
            hasCollison = hasCollision

        };
        return newObject;
    }

}