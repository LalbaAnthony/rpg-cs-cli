using System.Reflection.Metadata.Ecma335;

public class Room
{
    private int ID;
    private string Name;
    private Item Item;
    private Dictionary<string, Room> AdjacentRooms;
    private List<NPC> NPCs;

    public Room(int id, string name, Item item, Dictionary<string, Room> adjacentRooms, List<NPC> npcs)
    {
        ID = id;
        Name = name;
        Item = item;
        AdjacentRooms = adjacentRooms;
        NPCs = npcs;
    }

    // ====== GETTERS & SETTERS ======

    public int getID()
    {
        return ID;
    }

    public Item getItem()
    {
        return Item;
    }

    public void setItem(Item item)
    {
        Item = item;
    }

    public Dictionary<string, Room> getAdjacentRooms()
    {
        return AdjacentRooms;
    }

    public void setAdjacentRooms(Dictionary<string, Room> adjacentRooms)
    {
        AdjacentRooms = adjacentRooms;
    }

    public List<NPC> getNPCs()
    {
        return NPCs;
    }

    public void setNPCs(List<NPC> npcs)
    {
        NPCs = npcs;
    }

    // ====== METHODS ======

    public Item Search()
    {
        if (Item != null)
        {
            Console.WriteLine(value: $"You found a {Item.getName()}!");

            return Item;
        }
        else
        {
            Console.WriteLine("There's nothing here.");
            return null;
        }
    }

    public List<string> GetPossibleDirections()
    {
        return new List<string>(AdjacentRooms.Keys);
    }

    public void ClearItem()
    {
        Item = null;
    }

    public bool HasNPC()
    {
        return NPCs.Count > 0;
    }

    public void addAdjacentRoom(string direction, Room room)
    {
        AdjacentRooms.Add(direction, room);
    }

    public bool canGo(string direction)
    {
        return AdjacentRooms.ContainsKey(direction);
    }

    public Room GetAdjacentRoom(string direction)
    {
        return AdjacentRooms[direction];
    }

    public string getName()
    {
        return Name;
    }
}
