public class Vento : Plantes
{
    public Vento()
    {
        Nom = "Vento";
        Emoji = "🧄";
        Type = "Annuelle";
        Comestible = true;
        MauvaiseHerbe = false;
        SaisonSemis = "Printemps";

        VitesseCroissance = 10;
        TerrainPrefere = "Terre";
        BesoinEau = 70;

        TempsDeVieRestant = 100; // durée de vie initiale
        Vulnerabilites = new Dictionary<string, float>
        {
            { "Gel", 0.2f },
            { "Sécheresse", 0.3f },
            { "Insectes", 0.15f }
        };
    }
}
