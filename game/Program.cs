using System;
using System.Collections.Generic;

public class Game
{
    // Game
    static public int game_max_life = 3;

    // Player
    private int player_life { get; set; } = 2;
    private int player_score { get; set; } = 0;
    private List<string> inventory = new List<string>();
    private bool hasKey = false;

    public void IncrementScore(int value = 1)
    {
        player_score += value;
    }

    static void DisplayHelp()
    {
        Helpers.PrintTitle("Help");
        Console.WriteLine("1. You have to find the key to open the door and escape the room.");
        Console.WriteLine("2. You can move to the next room by typing the direction: [left], [right], [front], [behind], [top], [bottom]).");
        Console.WriteLine("3. You can type [talk] to interact with NPCs in the current room.");
        Console.WriteLine("4. You can type [search] to search for items in the current room.");
        Console.WriteLine("5. You can type [inventory] to see your inventory.");
        Console.WriteLine("6. You can type [score] to see your score.");
        Console.WriteLine("7. You can type [life] to see your life.");
        Console.WriteLine("7. You can type [infos] to see all infos above as: inventory, score, life.");
        Console.WriteLine("9. You can type [over] to quit the game.");
        Console.WriteLine("10. You can type [help] to see this message again.");
        Helpers.PrintLine();
    }

    void Start()
    {
        Helpers.PrintGameName();
        DisplayHelp();
        Map.Initialize();
        GameLoop();
    }

    void DisplayGameOver()
    {
        Helpers.PrintTitle("Game Over!");
        Console.WriteLine("You have lost all your life.");
        Console.WriteLine("Thanks for playing!");
        Helpers.PrintLine();
    }

    void HandleCommande(string command)
    {
        switch (command)
        {
            case "left":
            case "right":
            case "front":
            case "behind":
            case "top":
            case "bottom":
                Move(command);
                IncrementScore();
                break;
            case "search":
                Map.CurrentRoom.Search();
                break;
            case "talk":
            //Map.CurrentRoom.InteractWithNPC();
            case "inventory":
                DisplayInventory();
                break;
            case "score":
                DisplayScore();
                break;
            case "life":
                DisplayLife();
                break;
            case "infos":
                DisplayInfos();
                break;
            case "over":
                DisplayGameOver();
                return;
            case "help":
                DisplayHelp();
                break;
            default:
                Console.WriteLine("Unknown command. Type [help] for the list of commands.");
                break;
        }
    }

    void GameLoop()
    {
        while (true)
        {
            if (player_life <= 0)
            {
                DisplayGameOver();
                return;
            }

            Helpers.PrintChevron();
            string command = Console.ReadLine().Trim().ToLower();

            HandleCommande(command);
        }
    }

    void DisplayInventory()
    {
        Helpers.PrintTitle("Inventory");
        if (inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
        Helpers.PrintLine();
    }

    void DisplayScore()
    {
        Helpers.PrintTitle("Score");
        Console.WriteLine($"Your score is: {player_score}");
        Helpers.PrintLine();
    }

    void DisplayLife()
    {
        Helpers.PrintTitle("Life");
        Helpers.PrintLife(player_life, game_max_life);
        Helpers.PrintLine();
    }

    void PrintWhereAmI()
    {
        Console.WriteLine($"You are in {Map.CurrentRoom.Name}");
    }

    void DisplayWhereAmI()
    {
        Helpers.PrintTitle("Where am I?");
        PrintWhereAmI();
        Helpers.PrintLine();
    }

    void DisplayInfos()
    {
        DisplayWhereAmI();
        DisplayInventory();
        DisplayScore();
        DisplayLife();
    }

    public static void Move(string direction)
    {
        if (Map.CurrentRoom.AdjacentRooms.ContainsKey(direction))
        {
            Map.CurrentRoom = Map.CurrentRoom.AdjacentRooms[direction];
            Console.WriteLine();
            Console.WriteLine($"You moved to {Map.CurrentRoom.Name}");
            Console.WriteLine();
            WhereCanIGo();
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
    }

    public static void WhereCanIGo()
    {
        Console.WriteLine("You can go: ");
        foreach (var direction in Map.CurrentRoom.AdjacentRooms.Keys)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(direction);
            Console.ResetColor();
            Console.Write("]");
            Console.Write("  ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}
