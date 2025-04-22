class Monde
{
    private Case[,] plateau;
    public int Largeur{get; set;}
    public int Hauteur{get; set;}

    public Monde(int largeur, int hauteur)
    {
        Largeur = largeur;
        Hauteur = hauteur;

        plateau = new Case[Hauteur*2+1, Largeur*2+1];

        for (int y = 0; y < Hauteur*2+1; y++)
        {
            for (int x = 0; x < Largeur*2+1; x++)
            {
                plateau[y, x] = new Case(x,y);
            }
        }
    }

    public void ChangerCouleurCase(int x, int y, ConsoleColor couleur)
    {
        plateau[y, x].Couleur = couleur;
    }

    public void AfficherCase(Case laCase)
{
    string txt = ".";

    int x = laCase.CoordX;
    int y = laCase.CoordY;
    int maxX = Largeur * 2;
    int maxY = Hauteur * 2;

    if (x % 2 != 0 && y % 2 != 0)
        txt = "   "; // Case vide (intérieure)
    else if (x % 2 != 0 && y % 2 == 0)
        txt = "═══"; // Mur horizontal
    else if (x % 2 == 0 && y % 2 != 0)
        txt = "║"; // Mur vertical
    else // Coin (intersection)
    {
        if (x == 0 && y == 0)
            txt = "╔";
        else if (x == maxX && y == 0)
            txt = "╗";
        else if (x == 0 && y == maxY)
            txt = "╚";
        else if (x == maxX && y == maxY)
            txt = "╝";
        else if (y == 0)
            txt = "╦";
        else if (y == maxY)
            txt = "╩";
        else if (x == 0)
            txt = "╠";
        else if (x == maxX)
            txt = "╣";
        else
            txt = "╬";
    }

    Console.ForegroundColor = laCase.Couleur;
    Console.Write(txt);
    Console.ResetColor();
}


    public void AfficherPlateau()
    {
        for (int y = 0; y < Hauteur*2+1; y++)
        {
            for (int x = 0; x < Largeur*2+1; x++)
            {
                AfficherCase(plateau[y, x]);
            }
            Console.WriteLine();
        }
    }
}
