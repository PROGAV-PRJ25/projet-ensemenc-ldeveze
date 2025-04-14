public class Plantes 
{
    private string type;

    public string Type {
        get {return type;}
        set {
            if (value != "Vivace" && value != "Annuelle")
                throw new Exception("Type doit être 'Vivace' ou 'Annuelle'");
            type = value;
        }
    }

    public bool Comestible {get; set;}
    public bool MauvaiseHerbe {get; set;}

    private string saisonSemis;

    public string SaisonSemis {
        get {return saisonSemis;}
        set {
            if (value != "Hiver" && value != "Automne" && value != "Ete" && value != "Printemps")
                throw new Exception("saisonSemis doit être 'Hiver', 'Automne', 'Ete' ou 'Printemps'");
            saisonSemis = value;
        }
    }

    public int Vitesse{get; set;}
    public int NiveauCroissance{get; set;}
    
    public Plantes(string type, bool comestible, bool mauvaiseHerbe, string saisonSemis, int vitesse)
    {
        Type = type;
        Comestible = comestible;
        MauvaiseHerbe = mauvaiseHerbe;
        SaisonSemis = saisonSemis;
        Vitesse = vitesse;
        NiveauCroissance = 0;
    }

    public override string ToString()
    {
        return $"{Type}";
    }
}