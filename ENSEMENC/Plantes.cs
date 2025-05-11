

public class Plantes
{
    private string type;
    private string saisonSemis;

    public string Type
    {
        get => type;
        set
        {
            if (value != "Vivace" && value != "Annuelle")
                throw new ArgumentException("Type doit être 'Vivace' ou 'Annuelle'");
            type = value;
        }
    }

    public bool Comestible { get; set; }
    public bool MauvaiseHerbe { get; set; }

    public string SaisonSemis
    {
        get => saisonSemis;
        set
        {
            if (value != "Hiver" && value != "Automne" && value != "Ete" && value != "Printemps")
                throw new ArgumentException("SaisonSemis doit être 'Hiver', 'Automne', 'Ete' ou 'Printemps'");
            saisonSemis = value;
        }
    }

    public int Vitesse { get; set; }
    public int NiveauCroissance { get; set; }
    public int NbFruits { get; set; }

    public Plantes(string type, bool comestible, bool mauvaiseHerbe, string saisonSemis, int vitesse, int nbFruits)
    {
        Type = type;
        Comestible = comestible;
        MauvaiseHerbe = mauvaiseHerbe;
        SaisonSemis = saisonSemis;
        Vitesse = vitesse;
        NiveauCroissance = 0; // par défaut
        NbFruits = nbFruits;
    }

    public override string ToString()
    {
        return
$@"Type               : {Type}
Comestible         : {Comestible}
Mauvaise herbe     : {MauvaiseHerbe}
Saison de semis    : {SaisonSemis}
Vitesse de pousse  : {Vitesse}
Niveau de croissance : {NiveauCroissance}
Nombre de fruits   : {NbFruits}";
    }
}
