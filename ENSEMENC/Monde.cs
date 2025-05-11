using System;

// Classe représentant le monde (le plateau de jeu)
public class Monde
{
    // Dimensions du monde (déduites automatiquement à partir du schéma)
    public int Largeur { get; private set; }
    public int Hauteur { get; private set; }

    // Grille 2D contenant toutes les cases du monde
    public Case[,] Grille { get; private set; }

    // Position actuelle du joueur dans la grille
    public int JoueurX { get; set; }
    public int JoueurY { get; set; }

    // Constructeur du monde
    public Monde()
    {
        InitialiserMonde();      // Création des cases à partir d’un schéma
        JoueurX = 0;             // Position initiale du joueur (coin haut gauche)
        JoueurY = 0;
    }

    // Initialise le monde à partir d’un tableau de chaînes représentant les biomes
    private void InitialiserMonde()
    {
        // Schéma du monde défini manuellement (7 lignes x 7 colonnes)
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

        // On récupère automatiquement la taille du monde depuis le tableau
        Hauteur = schema.GetLength(0);
        Largeur = schema.GetLength(1);

        // On initialise la grille avec ces dimensions
        Grille = new Case[Largeur, Hauteur];

        // Pour chaque cellule du schéma, on crée une Case avec le biome correspondant
        for (int y = 0; y < Hauteur; y++)
        {
            for (int x = 0; x < Largeur; x++)
            {
                Grille[x, y] = new Case(schema[y, x]);
            }
        }
    }

    // Permet de planter un emoji (plante) à une position donnée
    public void Planter(int x, int y, Plantes plante)
    {
        if (x >= 0 && x < Largeur && y >= 0 && y < Hauteur)
        {
            Grille[x, y].Plante = plante;
        }
    }

    // Retourne la case actuellement sélectionnée par le joueur
    public Case GetCaseSelectionnee()
    {
        return Grille[JoueurX, JoueurY];
    }

    // Bouge le joueur avec les flèches directionnelles
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

    // Affiche la grille de jeu et les infos de la case sélectionnée
    public void AfficherMonde()
    {
        // Affichage ligne par ligne du plateau (chaque case étant un bloc 3x3)
        for (int y = 0; y < Hauteur; y++)
        {
            for (int ligneBloc = 0; ligneBloc < 3; ligneBloc++)
            {
                for (int x = 0; x < Largeur; x++)
                {
                    // Vérifie si c’est la case sur laquelle se trouve le joueur
                    bool estSelectionnee = (x == JoueurX && y == JoueurY);

                    // Récupère le bloc 3x3 à afficher
                    string[] bloc = Grille[x, y].GetEmojiBlock(estSelectionnee);

                    // Affiche la ligne actuelle de ce bloc
                    Console.Write(bloc[ligneBloc]);
                }
                Console.WriteLine(); // Passe à la ligne suivante après chaque ligne de bloc
            }
            Console.WriteLine(); // Ligne vide entre chaque rangée de cases
        }

        // Partie "HUD" affichée sous le plateau
        var c = GetCaseSelectionnee();

        Console.WriteLine("-----------------------------");
        Console.WriteLine(" Informations de la case :");
        Console.WriteLine($" - Biome : {c.Biome}");

        if (c.Plante != null)
        {
            Console.WriteLine();
            Console.WriteLine(c.Plante.AfficherInfos());
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine(" Aucune plante sur cette case.");
        }
        Console.WriteLine("-----------------------------");
    }
}
