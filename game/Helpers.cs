using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

public static class Helpers
{

    public static void PrintGameName()
    {
        Console.WriteLine("\n\n");
        Console.WriteLine(" $$$$$$\\   $$$$$$$\\  $$$$$$$\\ $$$$$$\\   $$$$$$\\   $$$$$$\\  ");
        Console.WriteLine("$$  __$$\\ $$  _____|$$  _____|\\____$$\\ $$  __$$\\ $$  __$$\\ ");
        Console.WriteLine("$$$$$$$$ |\\$$$$$$\\  $$ /      $$$$$$$ |$$ /  $$ |$$$$$$$$ |");
        Console.WriteLine("$$   ____| \\____$$\\ $$ |     $$  __$$ |$$ |  $$ |$$   ____|");
        Console.WriteLine("\\$$$$$$$\\ $$$$$$$  |\\$$$$$$$\\$$$$$$$ |$$$$$$$  |\\$$$$$$$\\ ");
        Console.WriteLine(" \\_______|\\_______/  \\_______|\\_______|$$  ____/  \\_______|");
        Console.WriteLine("                                       $$ |                ");
        Console.WriteLine("                                       $$ |                ");
        Console.WriteLine("                                       \\__|                ");
        Console.WriteLine("\n\n");
    }
    public static void PrintLine()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        Console.ResetColor();
    }

    public static void PrintChevron()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\n> ");
        Console.ResetColor();
    }

    public static void PrintTitle(string title)
    {
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("| ");
        Console.ResetColor();

        Console.Write(title);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" |");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine();
    }

    public static void PrintLife(int life, int max_life)
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Life: [");
        Console.ResetColor();

        for (int i = 0; i < max_life; i++)
        {
            if (i < life)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("]");
        Console.ResetColor();
        Console.WriteLine();
    }
}
