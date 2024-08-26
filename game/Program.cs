using System;
using System.Collections.Generic;

public class Game
{
    // Game constants

    static public int game_max_energy = 100;

    // PLayer related variables

    private int player_energy = 70;
    private int player_score = 0;
    private List<Item> inventory = new List<Item>();

    // Stats related methods

    public void IncrementScore(int value = 10)
    {
        player_score += value;
    }

    public void SetEnergy(int value)
    {
        if (player_energy < 0)
        {
            player_energy = 0;
        }
        else if (player_energy > game_max_energy)
        {
            player_energy = game_max_energy;
        }
        else
        {
            player_energy = value;
        }
    }

    public void IncrementEnergy(int value = 10)
    {
        SetEnergy(player_energy + value);
    }

    public void DecrementEnergy(int value = 1)
    {
        SetEnergy(player_energy - value);
    }

    public void Start()
    {
        Printers.PrintGameName();
        DisplayHelp();
        Map.Initialize();
        GameLoop();
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
                Map.CurrentRoom.ClearItem();
                break;
            case "talk":
                Talk(true);
                break;
            case "inventory":
                DisplayInventory();
                break;
            case "score":
                DisplayScore();
                break;
            case "energy":
                DisplayEnergy();
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
                Console.WriteLine(Dialogs.unknown_command);
                break;
        }
    }

    void GameLoop()
    {
        while (true)
        {
            Printers.PrintChevron();
            string command = Console.ReadLine().Trim().ToLower();

            HandleCommande(command);

            if (player_energy <= 0)
            {
                DisplayGameOver();
                return;
            }

            if (Map.CurrentRoom.getID() == 7 && inventory.Exists(item => item.getID() == 1)) // If in ground floor corridor and has key
            {
                DisplayGameWon();
                return;
            }
        }
    }

    void DisplayGameOver()
    {
        Printers.PrintTitle(Dialogs.game_over);
        Console.WriteLine(Dialogs.thanks_for_playing);
        Printers.PrintLine();
    }

    void DisplayGameWon()
    {
        Printers.PrintTitle(Dialogs.game_won);
        Console.WriteLine(Dialogs.thanks_for_playing);
        Printers.PrintLine();
    }

    void DisplayHelp()
    {
        Printers.PrintTitle("Help");
        Console.WriteLine("1. You have to find the key to open the door and escape the mansion.");
        Console.Write("2. You can move to the next room by typing the direction: ");
        Printers.PrintCommande("left");
        Console.Write(", ");
        Printers.PrintCommande("right");
        Console.Write(", ");
        Printers.PrintCommande("front");
        Console.Write(", ");
        Printers.PrintCommande("behind");
        Console.Write(", ");
        Printers.PrintCommande("top");
        Console.Write(", ");
        Printers.PrintCommande("bottom");
        Console.WriteLine();
        Console.Write("3. You can type ");
        Printers.PrintCommande("talk");
        Console.Write(" to interact with NPCs in the current room.");
        Console.WriteLine();
        Console.Write("4. You can type ");
        Printers.PrintCommande("search");
        Console.Write(" to search for items in the current room.");
        Console.WriteLine();
        Console.Write("5. You can type ");
        Printers.PrintCommande("inventory");
        Console.Write(" to see your inventory.");
        Console.WriteLine();
        Console.Write("6. You can type ");
        Printers.PrintCommande("score");
        Console.Write(" to see your score.");
        Console.WriteLine();
        Console.Write("7. You can type ");
        Printers.PrintCommande("energy");
        Console.Write(" to see your energy.");
        Console.WriteLine();
        Console.Write("8. You can type ");
        Printers.PrintCommande("infos");
        Console.Write(" to see all infos above as: inventory, score, energy.");
        Console.WriteLine();
        Console.Write("9. You can type ");
        Printers.PrintCommande("over");
        Console.Write(" to quit the game.");
        Console.WriteLine();
        Console.Write("10. You can type ");
        Printers.PrintCommande("help");
        Console.Write(" to see this message again.");
        Console.WriteLine();
        Printers.PrintLine();
    }

    void DisplayInventory()
    {
        Printers.PrintTitle("Inventory");
        if (inventory.Count == 0)
        {
            Console.WriteLine(Dialogs.GetRandomDialogueEmptyInventory());
        }
        else
        {
            foreach (var item in inventory)
            {
                Console.WriteLine(value: $"- {item.getName()}");
            }
        }
        Printers.PrintLine();
    }

    void DisplayScore()
    {
        Printers.PrintTitle("Score");
        Console.WriteLine($"Your score is: {player_score}");
        Printers.PrintLine();
    }

    void DisplayEnergy()
    {
        Printers.PrintTitle("Energy");

        int perten_player_energy = Helpers.ConvertToPercentage(player_energy, game_max_energy) / 10;
        Printers.PrintEnergy(perten_player_energy, 10);
        Printers.PrintLine();
    }

    void PrintWhereAmI()
    {
        Console.WriteLine($"You are in {Map.CurrentRoom.getName()}.");
    }

    void DisplayWhereAmI()
    {
        Printers.PrintTitle("Where am I?");
        PrintWhereAmI();
        Printers.PrintLine();
    }

    void DisplayWhereCanIGo()
    {
        Printers.PrintTitle("Where can I go?");
        WhereCanIGo();
        Printers.PrintLine();
    }

    void DisplayInfos()
    {
        DisplayWhereAmI();
        DisplayWhereCanIGo();
        DisplayInventory();
        DisplayScore();
        DisplayEnergy();
    }

    static void Talk(bool askedByPlayer = false)
    {
        if (Map.CurrentRoom.HasNPC())
        {
            foreach (var npc in Map.CurrentRoom.getNPCs())
            {
                Printers.PrintDialogue(npc.getName(), npc.GetRandomDialogue());
            }
        }
        else
        {
            if (askedByPlayer)
            {
                Console.WriteLine(Dialogs.GetRandomDialogueNoNPC());
            }
        }
    }

    void Move(string direction)
    {
        if (Map.CurrentRoom.canGo(direction))
        {
            Map.CurrentRoom = Map.CurrentRoom.GetAdjacentRoom(direction);
            Console.WriteLine();
            Console.WriteLine($"You moved to {Map.CurrentRoom.getName()}.");

            DecrementEnergy(1);

            foreach (var npc in Map.CurrentRoom.getNPCs())
            {
                Console.WriteLine($"You see {npc.getName()} in the room.");
            }
            Talk();
            Console.WriteLine();
            WhereCanIGo();
        }
        else
        {
            Console.WriteLine(Dialogs.GetRandomDialogueCantMove());
        }
    }

    void WhereCanIGo()
    {
        Console.Write("You can go: ");

        List<string> possibleDirections = Map.CurrentRoom.GetPossibleDirections();

        for (int i = 0; i < possibleDirections.Count; i++)
        {
            Printers.PrintCommande(possibleDirections[i]);

            if (i < possibleDirections.Count - 1)
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
