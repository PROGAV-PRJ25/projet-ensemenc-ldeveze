public class Gral : Plantes
{
    public Gral()
    {
        Nom = "Gral";
        Emoji = "🏵️ ";
        Type = "Ornementale";
        Comestible = false;
        MauvaiseHerbe = false;
        SaisonSemis = "Printemps";

        VitesseCroissance = 4;
        TerrainPrefere = "Argile";
        BesoinEau = 50;
        TempsDeVieRestant = 60;

        Vulnerabilites = new Dictionary<string, float>
        {
            { "Gel", 0.15f },
            { "Insectes", 0.1f }
        };
    }
}
