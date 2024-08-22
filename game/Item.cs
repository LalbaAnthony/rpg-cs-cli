public class Item
{
    public string Name { get; private set; }
    public bool Found { get; set; }

    public Item(string name)
    {
        Name = name;
        Found = false;
    }
}