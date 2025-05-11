public class Plantes
{
    // Informations de base
    public string Nom { get; set; }
    public string Emoji { get; set; }
    public string Type { get; set; } // "Annuelle" ou "Vivace"
    public bool Comestible { get; set; }
    public bool MauvaiseHerbe { get; set; }
    public string SaisonSemis { get; set; } // "Printemps", etc.

    // Croissance
    public int VitesseCroissance { get; set; } = 1; // unités par semaine
    public int NiveauCroissance { get; set; } = 0;  // max = 75
    public int NbFruitsMax { get; set; }
    public float Hauteur { get; set; } // en cm ou m

    // Besoins et préférences
    public string TerrainPrefere { get; set; } // "Terre", "Sable", etc.
    public int BesoinEau { get; set; } // échelle de 0 à 100 ?
    public int BesoinLuminosite { get; set; } // échelle 0–100
    public (int min, int max) TempPreferee { get; set; } // zone de température

    // Survie
    public float EsperanceVie { get; set; } = 100f; // diminue dans le temps
    public Dictionary<string, float> Vulnerabilites { get; set; } // ex: { "Gel" : 0.3f }

    // Constructeur simplifié (on peut créer plusieurs surcharges plus tard)
    public Plantes(string nom, string emoji)
    {
        Nom = nom;
        Emoji = emoji;
    }

    public string AfficherInfos()
    {
        string vuln = "";
        if (Vulnerabilites != null && Vulnerabilites.Count > 0)
        {
            foreach (var v in Vulnerabilites)
            {
                vuln += $"   \n• {v.Key} : {v.Value * 100}";
            }
        }

        return
        $@" Informations de la plante :
        - Nom : {Nom} {Emoji}
        - Type : {Type}
        - Comestible : {(Comestible ? "Oui" : "Non")}
        - Mauvaise herbe : {(MauvaiseHerbe ? "Oui" : "Non")}
        - Saison de semis : {SaisonSemis}
        - Croissance : {NiveauCroissance} / 75 unités
        - Nb fruits max : {NbFruitsMax}
        - Hauteur : {Hauteur} m
        - Terrain préféré : {TerrainPrefere}
        - Eau : {BesoinEau} / 100
        - Lumière : {BesoinLuminosite} / 100
        - Température idéale : {TempPreferee.min}–{TempPreferee.max}°C
        - Espérance de vie : {EsperanceVie:F1} %

        - Vulnérabilités :
        {vuln}";
    }

}
