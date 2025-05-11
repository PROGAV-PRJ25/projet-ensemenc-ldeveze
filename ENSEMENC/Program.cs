Console.OutputEncoding = System.Text.Encoding.UTF8;

Monde monde = new Monde();

var oignon = new Plantes("Oignon", "🧄")
{
    Type = "Annuelle",
    Comestible = true,
    MauvaiseHerbe = false,
    SaisonSemis = "Printemps",
    VitesseCroissance = 1,
    NbFruitsMax = 2,
    Hauteur = 0.4f,

    TerrainPrefere = "Terre",
    BesoinEau = 70,
    BesoinLuminosite = 60,
    TempPreferee = (10, 25),

    EsperanceVie = 100,
    Vulnerabilites = new Dictionary<string, float>
    {
        { "Gel", 0.2f },
        { "Sécheresse", 0.3f },
        { "Insectes", 0.15f }
    }
};

monde.Planter(2, 1, oignon);

bool enCours = true;
while (enCours)
{
    Console.Clear();
    monde.AfficherMonde();

    var key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Escape) enCours = false;
    else monde.BougerJoueur(key);
}