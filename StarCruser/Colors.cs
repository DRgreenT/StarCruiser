public class Color
{
    static string standard = "\u001b[0m";
    static string red = "\u001b[31m";
    static string green = "\u001b[32m";
    static string blue = "\u001b[34m";
    static string yellow = "\u001b[33m";
    static string orange = "\u001b[38;5;214m";
    static string magenta = "\u001b[35m";

    public static string Magenta(string str)
    {
        return magenta + str + standard;
    }
    public static string Orange(string str)
    {
        return orange + str + standard;
    }

    public static string Red(string str)
    {
        return red + str + standard;
    }
    public static string Green(string str)
    {
        return green + str + standard;
    }
    public static string Blue(string str)
    {
        return blue + str + standard;
    }
    public static string Yellow(string str)
    {
        return yellow + str + standard;
    }
}
