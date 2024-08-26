public class Item
{
    private int ID;
    private string Name;

    public Item(int id, string name)
    {
        ID = id;
        Name = name;
    }

    // ====== GETTERS & SETTERS ======

    public int getID()
    {
        return ID;
    }

    public string getName()
    {
        return Name;
    }

    public void setName(string name)
    {
        Name = name;
    }

    // Note: No setter for ID
}
