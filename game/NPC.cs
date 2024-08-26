public class NPC
{
    private int ID;
    private string Name;
    private List<(string Dialogue, double Probability)> Dialogues;
    private Random random;

    public NPC(int id, string name)
    {
        ID = id;
        Name = name;
        Dialogues = new List<(string Dialogue, double Probability)>();
        random = new Random();
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

    public List<(string Dialogue, double Probability)> getDialogues()
    {
        return Dialogues;
    }

    public void setDialogues(List<(string Dialogue, double Probability)> dialogues)
    {
        Dialogues = dialogues;
    }

    // ====== METHODS ======

    // Add a dialogue with a specific probability
    public void AddDialogue(string dialogue, double probability)
    {
        if (probability < 0 || probability > 1)
            throw new ArgumentException("Probability must be between 0 and 1.");

        Dialogues.Add((dialogue, probability));
    }

    // Method to select and return a dialogue based on probabilities
    public string GetRandomDialogue()
    {
        double roll = random.NextDouble();
        double cumulativeProbability = 0.0;

        foreach (var (dialogue, probability) in Dialogues)
        {
            cumulativeProbability += probability;
            if (roll < cumulativeProbability)
            {
                return dialogue;
            }
        }

        // If no dialogue was selected (shouldn't happen if probabilities sum to 1)
        return "...";
    }
}
