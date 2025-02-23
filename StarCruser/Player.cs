public class Player
{
    private string  _name;
    private int _posX;
    private int _posY;
    private int _lives;
    private int _level;
    private int _score;

    public bool _isCollidable = true;
    public Player Create()
    {
        return new Player();
    }

    // Getter-Methoden
    public string GetName() => _name;
    public int GetPosX() => _posX;
    public int GetPosY() => _posY;
    public int GetLives() => _lives;
    public int GetLevel() => _level;
    public int GetScore() => _score;

    // Setter-Methoden
    public void SetName(string name) => _name = name;
    public void SetPosX(int x) => _posX = x;
    public void SetPosY(int y) => _posY = y;
    public void SetLives(int lives) => _lives = lives;
    public void SetLevel(int level) => _level = level;
    public void SetScore(int score) => _score = score;


}

