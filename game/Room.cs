public class Room
{
    public string Name { get; set; }
    public string Item { get; set; }
    public Dictionary<string, Room> AdjacentRooms { get; set; }

    public Room(string name, string item, Dictionary<string, Room> adjacentRooms)
    {
        Name = name;
        Item = item;
        AdjacentRooms = adjacentRooms;
    }

    public void Search()
    {
        if (!string.IsNullOrEmpty(Item))
        {
            Console.WriteLine($"You found a {Item}!");
            Item = null; // Item is taken
        }
        else
        {
            Console.WriteLine("There's nothing here.");
        }
    }
}
