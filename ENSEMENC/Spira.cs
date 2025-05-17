public class Spira : Plantes
{
    public Spira()
    {
        Nom = "Spira";
        Emoji = "🥭";
        Type = "Fruitière";
        Comestible = true;
        MauvaiseHerbe = false;
        SaisonSemis = "Été";

        VitesseCroissance = 6;
        TerrainPrefere = "Terre";
        BesoinEau = 60;
        TempsDeVieRestant = 80;

        Vulnerabilites = new Dictionary<string, float>
        {
            { "Sécheresse", 0.35f },
            { "Insectes", 0.2f }
        };
    }
}
