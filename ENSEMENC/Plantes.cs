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

    public string TerrainPrefere { get; protected set; }
    public int BesoinEau { get; protected set; }

    public int TempsDeVieRestant { get; set; }

    public Dictionary<string, float> Vulnerabilites { get; protected set; } = new();

    public virtual void PasserUnJour(string biome, int eauContenue)
    {
        if (TempsDeVieRestant <= 0) return;

        TempsDeVieRestant--;

        if (biome != TerrainPrefere) TempsDeVieRestant--;
        int diff = Math.Abs(eauContenue - BesoinEau);
        if (diff >= 30) TempsDeVieRestant--;
        if (diff >= 50) TempsDeVieRestant--;

        if (NiveauCroissance < 100)
        {
            NiveauCroissance += VitesseCroissance;
            if (NiveauCroissance > 100) NiveauCroissance = 100;
        }
    }

    public string GetEmojiAffichage() =>
        TempsDeVieRestant <= 0 ? "🕳️ " :
        NiveauCroissance >= 100 ? Emoji : "🅿️ ";

    public string AfficherInfos(int eauContenue)
    {
        return $"Nom: {Nom} {Emoji} | Type: {Type} | Comestible: {(Comestible ? "Oui" : "Non")} | Mauvaise herbe: {(MauvaiseHerbe ? "Oui" : "Non")} | Saison: {SaisonSemis}\n" +
               $"Croissance: {NiveauCroissance}/100 | Terrain préféré: {TerrainPrefere} | Eau requise: {eauContenue}/{BesoinEau} | Vie restante: {TempsDeVieRestant} jours\n";
    }
}