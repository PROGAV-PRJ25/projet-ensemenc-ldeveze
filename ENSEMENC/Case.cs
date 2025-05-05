public class Case
{
    public string Biome { get; }
    public int X { get; }
    public int Y { get; }
    public string Image {get; }

    public Case(string biome, int x, int y, string image)
    {
        Biome = biome;
        X = x;
        Y = y;
        Image = image;
    }
}