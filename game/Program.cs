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

    public void IncrementScore(int value = 10)
    {
        player_score += value;
    }

    static void DisplayHelp()
    {
        Helpers.PrintTitle("Help");
        Console.WriteLine("1. You have to find the key to open the door and escape the room.");
        Console.Write("2. You can move to the next room by typing the direction: ");
        Helpers.PrintCommande("left");
        Console.Write(", ");
        Helpers.PrintCommande("right");
        Console.Write(", ");
        Helpers.PrintCommande("front");
        Console.Write(", ");
        Helpers.PrintCommande("behind");
        Console.Write(", ");
        Helpers.PrintCommande("top"); ;
        Console.Write(", ");
        Helpers.PrintCommande("bottom");
        Console.WriteLine();
        Console.Write("3. You can type ");
        Helpers.PrintCommande("talk");
        Console.Write(" to interact with NPCs in the current room.");
        Console.WriteLine();
        Console.Write("4. You can type ");
        Helpers.PrintCommande("search");
        Console.Write(" to search for items in the current room.");
        Console.WriteLine();
        Console.Write("5. You can type ");
        Helpers.PrintCommande("inventory");
        Console.Write(" to see your inventory.");
        Console.WriteLine();
        Console.Write("6. You can type ");
        Helpers.PrintCommande("score");
        Console.Write(" to see your score.");
        Console.WriteLine();
        Console.Write("7. You can type ");
        Helpers.PrintCommande("life");
        Console.Write(" to see your life.");
        Console.WriteLine();
        Console.Write("8. You can type ");
        Helpers.PrintCommande("infos");
        Console.Write(" to see all infos above as: inventory, score, life.");
        Console.WriteLine();
        Console.Write("9. You can type ");
        Helpers.PrintCommande("over");
        Console.Write(" to quit the game.");
        Console.WriteLine();
        Console.Write("10. You can type ");
        Helpers.PrintCommande("help");
        Console.Write(" to see this message again.");
        Console.WriteLine();
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
                inventory.Add(Map.CurrentRoom.Search());
                break;
            case "talk":
                Talk();
                break;
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

    void DisplayWhereCanIGo()
    {
        Helpers.PrintTitle("Where can I go?");
        WhereCanIGo();
        Helpers.PrintLine();
    }

    void DisplayInfos()
    {
        DisplayWhereAmI();
        DisplayWhereCanIGo();
        DisplayInventory();
        DisplayScore();
        DisplayLife();
    }

    public static void Talk()
    {
        if (Map.CurrentRoom.NPCs.Count > 0)
        {
            foreach (var npc in Map.CurrentRoom.NPCs)
            {
                Helpers.PrintDialogue(npc.Name, npc.GetRandomDialogue());
            }
        }
    }
    
    public static void Move(string direction)
    {
        if (Map.CurrentRoom.AdjacentRooms.ContainsKey(direction))
        {
            Map.CurrentRoom = Map.CurrentRoom.AdjacentRooms[direction];
            Console.WriteLine();
            Console.WriteLine($"You moved to {Map.CurrentRoom.Name}.");
            foreach (var npc in Map.CurrentRoom.NPCs)
            {
                Console.WriteLine($"You see {npc.Name}.");
            }
            Talk();
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
        Console.Write("You can go: ");

        int count = 0;
        int totalDirections = Map.CurrentRoom.AdjacentRooms.Keys.Count;

        foreach (var direction in Map.CurrentRoom.AdjacentRooms.Keys)
        {
            Helpers.PrintCommande(direction);
            count++;

            // Add a comma only if this is not the last element
            if (count < totalDirections)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }


    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}
