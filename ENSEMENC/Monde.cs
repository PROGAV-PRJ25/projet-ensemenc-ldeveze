using System;

// Classe représentant le monde (le plateau de jeu)
public class Monde
{
    public int Largeur { get; private set; }
    public int Hauteur { get; private set; }
    public Case[,] Grille { get; private set; }
    public int JoueurX { get; set; }
    public int JoueurY { get; set; }
    public int Jour { get; private set; } = 0;

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

    public void Planter(Plantes plante)
    {
        Grille[JoueurX, JoueurY].Plante = plante;
    }

    public void AfficherMenuPlantesEtPlanter()
    {
        Console.Clear();
        Console.WriteLine("Sélectionnez une plante à planter :");
        Console.WriteLine("[E] Vento 🧄");
        Console.WriteLine("[R] Vira 🥬");
        Console.WriteLine("[T] Luma 🦠");
        Console.WriteLine("[Y] Spira 🥭");
        Console.WriteLine("[U] Gral 🏵️");

        ConsoleKey key = Console.ReadKey(true).Key;

        Plantes? planteChoisie = key switch
        {
            ConsoleKey.E => new Vento(),
            ConsoleKey.R => new Vira(),
            ConsoleKey.T => new Luma(),
            ConsoleKey.Y => new Spira(),
            ConsoleKey.U => new Gral(),
            _ => null
        };

        if (planteChoisie != null)
        {
            Planter(planteChoisie);
        }
    }


    public void AvancerUnJour()
    {
        Jour++;
        foreach (var c in Grille)
        {
            if (c.Plante != null)
            {
                c.Plante.PasserUnJour(c.Biome, c.EauContenue);
                if (c.Plante.TempsDeVieRestant <= 0)
                {
                    // La plante meurt, on garde l'objet pour l'emoji mort
                    c.Plante.NiveauCroissance = 0;
                }
            }
        }
    }


    public Case GetCaseSelectionnee() => Grille[JoueurX, JoueurY];

    public void BougerJoueur(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:  if (JoueurX > 0) JoueurX--; break;
            case ConsoleKey.RightArrow: if (JoueurX < Largeur - 1) JoueurX++; break;
            case ConsoleKey.UpArrow:    if (JoueurY > 0) JoueurY--; break;
            case ConsoleKey.DownArrow:  if (JoueurY < Hauteur - 1) JoueurY++; break;
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

        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Jour actuel : {Jour}");

        var c = GetCaseSelectionnee();
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Biome de la case : {c.Biome}");
        if (c.Plante != null)
        {
            Console.WriteLine("\nInformation sur la plante : \n");
            Console.WriteLine(c.Plante.AfficherInfos());
        }
        else
        {
            Console.WriteLine("Pas de plante");
        }
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Actions possibles : ");
        Console.WriteLine("P : Planter | A : Arroser | C : Chasser");
        Console.WriteLine("-----------------------------");
    }
}