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

    public void incrementScore(int value = 1)
    {
        player_score += value;
    }

    static void displayHelp()
    {
        Helpers.printTitle("Help");
        Console.WriteLine("1. You have to find the key to open the door and escape the room.");
        Console.WriteLine("2. You can move to the next room by typing the direction: [left], [right], [front], [behind]).");
        Console.WriteLine("3. You can type [inventory] to see your inventory.");
        Console.WriteLine("4. You can type [score] to see your score.");
        Console.WriteLine("5. You can type [life] to see your life.");
        Console.WriteLine("6. You can type [infos] to see all infos above as: inventory, score, life.");
        Console.WriteLine("7. You can type [over] to quit the game.");
        Console.WriteLine("8. You can type [help] to see this message again.");
        Helpers.printLine();
    }

    void start()
    {
        Helpers.printGameName();
        displayHelp();
        gameLoop();
    }

    void displayGameOver()
    {
        Helpers.printTitle("Game Over!");
        Console.WriteLine("You have lost all your life.");
        Console.WriteLine("Thanks for playing!");
        Helpers.printLine();
    }

    void handleCommande(string command)
    {
        switch (command)
        {
            case "left":
            case "right":
            case "front":
            case "behind":
                move(command);
                break;
            case "inventory":
                displayInventory();
                break;
            case "score":
                displayScore();
                break;
            case "life":
                displayLife();
                break;
            case "infos":
                displayInfos();
                break;
            case "over":
                displayGameOver();
                return;
            case "help":
                displayHelp();
                break;
            default:
                Console.WriteLine("Unknown command. Type [help] for the list of commands.");
                break;
        }
    }

    void gameLoop()
    {
        while (true)
        {
            if (player_life <= 0)
            {
                displayGameOver();
                return;
            }

            Helpers.printChevron();
            string command = Console.ReadLine().Trim().ToLower();

            handleCommande(command);
        }
    }

    void move(string direction)
    {
        // Simplified movement logic
        Console.WriteLine($"You moved {direction}. Searching the room...");

        // Random event for finding a key
        Random random = new Random();
        if (random.Next(1, 5) == 1 && !hasKey)
        {
            Console.WriteLine("You found a key!");
            inventory.Add("key");
            hasKey = true;
        }
        else
        {
            Console.WriteLine("Nothing found in this room.");
        }

        incrementScore(); // Increase score for moving
    }

    void displayInventory()
    {
        Helpers.printTitle("Inventory");
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
        Helpers.printLine();
    }

    void displayScore()
    {
        Helpers.printTitle("Score");
        Console.WriteLine($"Your score is: {player_score}");
        Helpers.printLine();
    }

    void displayLife()
    {
        Helpers.printTitle("Life");
        Helpers.printLife(player_life, game_max_life);
        Helpers.printLine();
    }

    void displayInfos()
    {
        displayInventory();
        displayScore();
        displayLife();
    }

    public static void Main(string[] args)
    {
        Game game = new Game();
        game.start();
    }
}
