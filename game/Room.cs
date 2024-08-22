public class Room
{
    public string Name { get; set; }
    public Item Item { get; set; }

    public Dictionary<string, Room> AdjacentRooms { get; set; }
    public List<NPC> NPCs { get; set; }

    public Room(string name, Item item, Dictionary<string, Room> adjacentRooms, List<NPC> npcs)
    {
        Name = name;
        Item = item;
        AdjacentRooms = adjacentRooms;
        NPCs = npcs;
    }

    public Item Search()
    {
        if (!Item.Found)
        {
            Console.WriteLine($"You found a {Item.Name}!");

            return Item; // Item is taken
        }
        else
        {
            Console.WriteLine("There's nothing here.");
            return null;
        }
    }
}
