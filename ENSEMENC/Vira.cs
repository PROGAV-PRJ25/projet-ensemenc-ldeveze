public class Vira : Plantes
{
    public Vira()
    {
        Nom = "Vira";
        Emoji = "🥬";
        Type = "Vivace";
        Comestible = true;
        MauvaiseHerbe = false;
        SaisonSemis = "Automne";

        VitesseCroissance = 5;
        TerrainPrefere = "Argile";
        BesoinEau = 80;
        TempsDeVieRestant = 50;

        Vulnerabilites = new Dictionary<string, float>
        {
            { "Insectes", 0.25f },
            { "Sécheresse", 0.4f }
        };
    }
}
