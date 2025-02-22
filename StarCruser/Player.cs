public class Player
{
    public string name { get; set; }
    public int posX { get; set; }
    public int posY { get; set; }
    public int lives { get; set; }
    public int level { get; set; }
    public int score { get; set; }

    public bool isCollidable = true;

    public static Player Create()
    {
        return new Player();
    }
}

