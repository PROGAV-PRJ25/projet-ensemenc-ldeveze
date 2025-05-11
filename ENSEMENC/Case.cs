public class Case
{
    public string Biome { get; }
    public Plantes? Plante { get; set; }

    public Case(string biome)
    {
        Biome = biome;
    }

    private string FondEmoji()
    {
        return Biome switch
        {
            "Terre" => "🟫",
            "Sable" => "🟨",
            "Argile" => "🟥",
            _       => "⬛️"
        };
    }

    public string[] GetEmojiBlock(bool estSelectionnee)
    {
        string fond = estSelectionnee ? "🟪" : FondEmoji();
        string centre = Plante?.Emoji ?? fond;

        return new string[]
        {
            $"{fond}{fond}{fond}",
            $"{fond}{centre}{fond}",
            $"{fond}{fond}{fond}"
        };
    }
}
