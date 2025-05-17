using System;
using System.Collections.Generic;

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
            { "Terre", "Terre", "Terre", "Terre", "Sable", "Sable", "Sable" },
            { "Terre", "Terre", "Terre", "Terre", "Sable", "Sable", "Sable" },
            { "Terre", "Terre", "Terre", "Sable", "Sable", "Sable", "Sable" },
            { "Terre", "Argile", "Argile", "Sable", "Sable", "Sable", "Sable" },
            { "Argile", "Argile", "Argile", "Argile", "Terre", "Terre", "Sable" },
            { "Argile", "Argile", "Argile", "Argile", "Terre", "Terre", "Terre" },
            { "Argile", "Argile", "Argile", "Terre", "Terre", "Terre", "Terre" }
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
        var c = GetCaseSelectionnee();
        if (c.AraigneePresente)
        {
            Console.WriteLine("❌ Impossible de planter ici, une araignée est présente !");
            Thread.Sleep(1000);
            return;
        }

        c.Plante = plante;
    }

    private void AjouterAraigneesAleatoires()
    {
        Random rnd = new();
        foreach (var c in Grille)
        {
            // 1% de chance d'apparition chaque jour
            if (!c.AraigneePresente && rnd.NextDouble() < 0.01)
            {
                c.AraigneePresente = true;
            }
        }
    }


    public void ArroserCaseSelectionnee()
    {
        var c = GetCaseSelectionnee();
        c.EauContenue += 10;
        if (c.EauContenue > 100) c.EauContenue = 100;
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
            // L'eau s'évapore un peu chaque jour
            c.EauContenue -= 2;
            if (c.EauContenue < 0) c.EauContenue = 0;

            if (c.Plante != null)
            {
                c.Plante.PasserUnJour(c.Biome, c.EauContenue);
                if (c.Plante.TempsDeVieRestant <= 0)
                {
                    c.Plante.NiveauCroissance = 0;
                }
            }
        }

        AjouterAraigneesAleatoires();
    }

    public void ChasserAraignee()
    {
        var c = GetCaseSelectionnee();
        if (c.AraigneePresente)
        {
            c.AraigneePresente = false;
            Console.WriteLine("🕷️ Vous avez chassé l'araignée !");
        }
        else
        {
            Console.WriteLine("Il n’y a pas d’araignée ici.");
        }
        Thread.Sleep(800);
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
        Console.WriteLine("-----------------------------");

        var c = GetCaseSelectionnee();
        Console.WriteLine($"Biome de la case : {c.Biome}");

        if (c.Plante != null)
        {
            Console.WriteLine("\nInformation sur la plante :\n");
            Console.WriteLine(c.Plante.AfficherInfos(c.EauContenue));
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
