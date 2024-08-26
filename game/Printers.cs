using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

public static class Printers
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        Console.ResetColor();
    }

    public static void PrintCommande(string commande)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(commande);
        Console.ResetColor();
        Console.Write("]");
    }

    public static void PrintDialogue(string name, string dialogue)
    {
        PrintChevron();

        Console.Write("@");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(name);
        Console.ResetColor();

        Console.Write(": ");
        Console.ResetColor();

        Console.Write(dialogue);
        Console.WriteLine();
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

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("| ");
        Console.ResetColor();

        Console.Write(title);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" |");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine();
    }

    public static void PrintEnergy(int energy, int max_energy)
    {
        Console.Write("Energy: [");
        Console.ResetColor();

        for (int i = 0; i < max_energy; i++)
        {
            if (i < energy)
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

        Console.Write("]");
        Console.ResetColor();
        Console.WriteLine();
    }
}
