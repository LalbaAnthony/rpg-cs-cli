// See https://aka.ms/new-console-template for more 

// class Room
// {
//     public string Name { get; set; }
//     public string Description { get; set; }
//     public Dictionary<string, Room> Exits { get; set; }

//     public Room(string name, string description)
//     {
//         Name = name;
//         Description = description;
//         Exits = new Dictionary<string, Room>();
//     }

//     public void Describe()
//     {
//         Console.WriteLine($"{Name}: {Description}");
//         Console.WriteLine("Exits: " + string.Join(", ", Exits.Keys));
//     }
// }

public class Game
{

    // ============= Game configuration =============
    static public int game_max_life = 3;

    // ============= Game configuration =============

    protected int life = game_max_life;

    //public void printGameName()
    //{
    //    Console.WriteLine("\n\n\n");
    //    Console.WriteLine(" $$$$$$\\   $$$$$$$\\  $$$$$$$\\ $$$$$$\\   $$$$$$\\   $$$$$$\\  ");
    //    Console.WriteLine("$$  __$$\\ $$  _____|$$  _____|\\____$$\\ $$  __$$\\ $$  __$$\\ ");
    //    Console.WriteLine("$$$$$$$$ |\\$$$$$$\\  $$ /      $$$$$$$ |$$ /  $$ |$$$$$$$$ |");
    //    Console.WriteLine("$$   ____| \\____$$\\ $$ |     $$  __$$ |$$ |  $$ |$$   ____|");
    //    Console.WriteLine("\\$$$$$$$\\ $$$$$$$  |\\$$$$$$$\\$$$$$$$ |$$$$$$$  |\\$$$$$$$\\ ");
    //    Console.WriteLine(" \\_______|\\_______/  \\_______|\\_______|$$  ____/  \\_______|");
    //    Console.WriteLine("                                       $$ |                ");
    //    Console.WriteLine("                                       $$ |                ");
    //    Console.WriteLine("                                       \\__|                ");
    //    Console.WriteLine("\n\n\n");
    //}

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to\n");
        //printGameName();
        //Console.WriteLine("You have " + this.life + " lives.");
    }
}

