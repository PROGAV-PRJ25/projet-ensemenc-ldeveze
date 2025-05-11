using System;

public class Monde
{
    public int Largeur { get; private set; }
    public int Hauteur { get; private set; }
    public Case[,] Grille { get; private set; }

    public int JoueurX { get; set; }
    public int JoueurY { get; set; }

    public Monde()
    {
        InitialiserMonde();
        JoueurX = 0;
        JoueurY = 0;
    }

    private void InitialiserMonde()
    {
        string[,] schema = new string[,]
        {
            { "Terre", "Terre", "Terre", "Terre", "Sable" , "Sable" , "Sable" },
            { "Terre", "Terre", "Terre", "Terre", "Sable" , "Sable" , "Sable" },
            { "Terre", "Terre", "Terre", "Sable", "Sable" , "Sable" , "Sable" },
            { "Terre", "Argile", "Argile", "Sable", "Sable" , "Sable" , "Sable" },
            { "Argile", "Argile", "Argile", "Argile", "Terre" , "Terre" , "Sable" },
            { "Argile", "Argile", "Argile", "Argile", "Terre" , "Terre" , "Terre" },
            { "Argile", "Argile", "Argile", "Terre", "Terre" , "Terre" , "Terre" }
        };

        Hauteur = schema.GetLength(0);
        Largeur = schema.GetLength(1);
        Grille = new Case[Largeur, Hauteur];

        for (int y = 0; y < Hauteur; y++)
        {
            for (int x = 0; x < Largeur; x++)
            {
                Grille[x, y] = new Case(schema[y, x]);
            }
        }
    }

    public void Planter(int x, int y, string emoji)
    {
        if (x >= 0 && x < Largeur && y >= 0 && y < Hauteur)
        {
            Grille[x, y].PlanteEmoji = emoji;
        }
    }

    public void BougerJoueur(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow: if (JoueurX > 0) JoueurX--; break;
            case ConsoleKey.RightArrow: if (JoueurX < Largeur - 1) JoueurX++; break;
            case ConsoleKey.UpArrow: if (JoueurY > 0) JoueurY--; break;
            case ConsoleKey.DownArrow: if (JoueurY < Hauteur - 1) JoueurY++; break;
        }
    }

    public void AfficherMonde()
    {
        for (int y = 0; y < Hauteur; y++)
        {
            for (int ligneBloc = 0; ligneBloc < 3; ligneBloc++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    bool estSelectionnee = (x == JoueurX && y == JoueurY);
                    string[] bloc = Grille[x, y].GetEmojiBlock(estSelectionnee);
                    Console.Write(bloc[ligneBloc]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
