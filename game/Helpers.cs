public static class Helpers
{
    public static int ConvertToPercentage(float value, float max = 100)
    {
        return (int)Math.Round(value / max * 100);
    }
}
