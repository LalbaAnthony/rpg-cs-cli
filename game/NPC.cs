public class NPC
{
    public string Name { get; private set; }
    private List<(string Dialogue, double Probability)> Dialogues { get; set; }
    private Random random;

    public NPC(string name)
    {
        Name = name;
        Dialogues = new List<(string Dialogue, double Probability)>();
        random = new Random();
    }

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