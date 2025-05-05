public class Case
{
    public string Biome { get; }
    public int X { get; }
    public int Y { get; }

    public Case(string biome, int x, int y)
    {
        Biome = biome;
        X = x;
        Y = y;
    }
}