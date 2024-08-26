public static class Dialogs
{
    public static List<string> no_npc_dialogs = new List<string>
    {
        "Seems like you're talking to yourself...",
        "You're alone in the room, no one can hear you.",
        "You're alone, no one can hear you.",
    };
    public static List<string> empty_inventory = new List<string>
    {
        "Your inventory is empty.",
        "You don't have anything in your inventory.",
        "You don't have anything.",
    };
    public static List<string> cant_move = new List<string>
    {
        "You can't go that way.",
        "You can't move in that direction.",
        "You can't go there.",
    };

    public static string unknown_command = "Unknown command. Type [help] for the list of commands.";
    public static string thanks_for_playing = "Thanks for playing!";
    public static string game_over = "Game Over";
    public static string game_won = "Congratulations! You escaped!";

    public static string GetRandomDialogueNoNPC()
    {
        Random random = new Random();
        return no_npc_dialogs[random.Next(no_npc_dialogs.Count)];
    }

    public static string GetRandomDialogueEmptyInventory()
    {
        Random random = new Random();
        return empty_inventory[random.Next(empty_inventory.Count)];
    }

    public static string GetRandomDialogueCantMove()
    {
        Random random = new Random();
        return cant_move[random.Next(cant_move.Count)];
    }
}
