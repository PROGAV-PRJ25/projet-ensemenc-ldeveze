public class Case
{
    public string Biome { get; }
    public Plantes? Plante { get; set; }
    public int EauContenue { get; set; }
    public bool AraigneePresente { get; set; } = false;

    public Case(string biome)
    {
        Biome = biome;
        EauContenue = 50;
    }

    private string FondEmoji() => Biome switch
    {
        "Terre" => "🟫",
        "Sable" => "🟨",
        "Argile" => "🟥",
        _ => "⬛"
    };

    public string[] GetEmojiBlock(bool estSelectionnee)
    {
        string fond = estSelectionnee ? "🟪" : FondEmoji();
        string centre = AraigneePresente ? "🕷️ " : Plante?.GetEmojiAffichage() ?? fond;

        return new[]
        {
            $"{fond}{fond}{fond}",
            $"{fond}{centre}{fond}",
            $"{fond}{fond}{fond}"
        };
    }
}
