public class Room
{
    public string Name { get; set; }
    public string Item { get; set; }
    public string Found { get; set; }

    public Dictionary<string, Room> AdjacentRooms { get; set; }
    public List<NPC> NPCs { get; set; }


    public Room(string name, string item, Dictionary<string, Room> adjacentRooms, List<NPC> npcs)
    {
        Name = name;
        Item = item;
        AdjacentRooms = adjacentRooms;
        NPCs = npcs;
    }

    public string Search()
    {
        if (!string.IsNullOrEmpty(Item))
        {
            Console.WriteLine($"You found a {Item}!");

            Found = Item;
            Item = null; // Item is taken
            return Found;
        }
        else
        {
            Console.WriteLine("There's nothing here.");
            return null;
        }

    }
}
