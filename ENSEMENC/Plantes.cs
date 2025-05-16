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
        // Ajustement du temps de vie selon terrain
        if (biome != TerrainPrefere)
            TempsDeVieRestant -= 5; // pénalité si le terrain n'est pas adapté
        else
            TempsDeVieRestant -= 1;

        // Ajustement selon l'eau contenue
        int difference = Math.Abs(eauContenue - BesoinEau);
        if (difference <= 10)
            TempsDeVieRestant += 1; // bonus si eau proche du besoin
        else if (difference <= 30)
            TempsDeVieRestant -= 2;
        else
            TempsDeVieRestant -= 5;

        // Croissance si encore en vie
        if (TempsDeVieRestant > 0 && NiveauCroissance < 100)
        {
            NiveauCroissance += VitesseCroissance;
            if (NiveauCroissance > 100) NiveauCroissance = 100;
        }
    }

    public string GetEmojiAffichage()
    {
        return TempsDeVieRestant <= 0 ? "🕳️ " :
               NiveauCroissance >= 100 ? Emoji : "🅿️ ";
    }

    public override string ToString() => $"{Nom} {Emoji}";

    public string AfficherInfos()
    {
        return $"Nom: {Nom} {Emoji} | Type: {Type} | Comestible: {(Comestible ? "Oui" : "Non")} | Mauvaise herbe: {(MauvaiseHerbe ? "Oui" : "Non")} | Saison: {SaisonSemis}\n" +
               $"Croissance: {NiveauCroissance}/100 | Terrain préféré: {TerrainPrefere}\n" +
               $"Eau requise: {BesoinEau}/100 | Temps de vie restant: {TempsDeVieRestant} jours\n";
    }
}
