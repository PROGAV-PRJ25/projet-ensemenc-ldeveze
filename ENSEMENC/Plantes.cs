public abstract class Plantes
{
    public string Nom { get; protected set; }
    public string Emoji { get; protected set; }
    public string Type { get; protected set; }
    public bool Comestible { get; protected set; }
    public bool MauvaiseHerbe { get; protected set; }
    public string SaisonSemis { get; protected set; }

    public int VitesseCroissance { get; protected set; } = 1;
    public int NiveauCroissance { get; set; } = 0;
    public int NbFruitsMax { get; protected set; }
    public float Hauteur { get; protected set; }

    public string TerrainPrefere { get; protected set; }
    public int BesoinEau { get; protected set; }
    public int BesoinLuminosite { get; protected set; }
    public (int min, int max) TempPreferee { get; protected set; }

    public float EsperanceVie { get; set; } = 100f;
    public Dictionary<string, float> Vulnerabilites { get; protected set; } = new();

    public virtual void PasserUnJour()
    {
        if (NiveauCroissance < 100)
        {
            NiveauCroissance += VitesseCroissance;
            if (NiveauCroissance > 100) NiveauCroissance = 100;
        }
    }

    public string GetEmojiAffichage()
    {
        return NiveauCroissance >= 100 ? Emoji : "🅿️ "; // 🅿️
    }

    public override string ToString()
    {
        return $"{Nom} {Emoji}";
    }

    public string AfficherInfos()
    {
        string vuln = "";
        foreach (var v in Vulnerabilites)
            vuln += $"   • {v.Key} : {v.Value * 100}%\n";

        return
$@" Informations de la plante :
 - Nom : {Nom} {Emoji}
 - Type : {Type}
 - Comestible : {(Comestible ? "Oui" : "Non")}
 - Mauvaise herbe : {(MauvaiseHerbe ? "Oui" : "Non")}
 - Saison de semis : {SaisonSemis}
 - Croissance : {NiveauCroissance} / 100 unités
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