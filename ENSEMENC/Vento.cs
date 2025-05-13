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
        NbFruitsMax = 2;
        Hauteur = 0.4f;

        TerrainPrefere = "Terre";
        BesoinEau = 70;
        BesoinLuminosite = 60;
        TempPreferee = (10, 25);

        EsperanceVie = 100;
        Vulnerabilites = new Dictionary<string, float>
        {
            { "Gel", 0.2f },
            { "Sécheresse", 0.3f },
            { "Insectes", 0.15f }
        };
    }
}