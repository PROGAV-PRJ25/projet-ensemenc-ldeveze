public class Luma : Plantes
{
    public Luma()
    {
        Nom = "Luma";
        Emoji = "🦠";
        Type = "Mutation";
        Comestible = false;
        MauvaiseHerbe = true;
        SaisonSemis = "Hiver";

        VitesseCroissance = 8;
        TerrainPrefere = "Sable";
        BesoinEau = 40;
        TempsDeVieRestant = 110;

        Vulnerabilites = new Dictionary<string, float>
        {
            { "Gel", 0.1f },
            { "Chaleur", 0.3f }
        };
    }
}
