public class Monde
{
    private int Largeur;
    private int Hauteur;
    private Case[,] plateau;
    private string[,] plateauAffichage;


    public Monde()
    {
        Largeur = 3;
        Hauteur = 3;

        // Initialiser d'abord plateauAffichage
        plateauAffichage = new string[Hauteur * 2 + 1, Largeur * 2 + 1];
        int maxX = Hauteur*2;
        int maxY = Largeur*2;

        for (int y = 0; y < Hauteur * 2 + 1; y++)
        {
            for (int x = 0; x < Largeur * 2 + 1; x++)
            {
                if (x % 2 != 0 && y % 2 == 0)
                    plateauAffichage[y, x] = "═══"; // Mur horizontal
                else if (x % 2 == 0 && y % 2 != 0)
                    plateauAffichage[y, x] = "║"; // Mur vertical
                else // Coin (intersection)
                {
                    if (x == 0 && y == 0)
                        plateauAffichage[y, x] = "╔";
                    else if (x == maxX && y == 0)
                        plateauAffichage[y, x] = "╗";
                    else if (x == 0 && y == maxY)
                        plateauAffichage[y, x] = "╚";
                    else if (x == maxX && y == maxY)
                        plateauAffichage[y, x] = "╝";
                    else if (y == 0)
                        plateauAffichage[y, x] = "╦";
                    else if (y == maxY)
                        plateauAffichage[y, x] = "╩";
                    else if (x == 0)
                        plateauAffichage[y, x] = "╠";
                    else if (x == maxX)
                        plateauAffichage[y, x] = "╣";
                    else
                        plateauAffichage[y, x] = "╬";
                }
            }
        }


        // Ensuite on peut créer les cases (car plateauAffichage existe)
        plateau = new Case[,]
        {
            {NewCase("Sable",0,0), NewCase("Argile",1,0), NewCase("Argile",2,0)},
            {NewCase("Terre",0,1), NewCase("Argile",1,1), NewCase("Sable",2,1)},
            {NewCase("Argile",0,2), NewCase("Sable",1,2), NewCase("Sable",2,2)},
        };
    }

    public Case NewCase(string biome, int x, int y)
    {
        modifierPlateauAffichage(biome, x, y);
        return new Case(biome, x, y);
    }

    public void modifierPlateauAffichage(string biome, int x, int y) // faudra ajouter emoji
    {
        string symbole = biome switch
        {
            "Sable" => "S",
            "Terre" => "T",
            "Argile" => "A",
            _ => "?"
        };

        plateauAffichage[y * 2 + 1, x * 2 + 1] = symbole;
    }


    public void AfficherPlateau()
    {
        for (int y = 0; y < Hauteur * 2 + 1; y++)
        {
            for (int x = 0; x < Largeur * 2 + 1; x++)
            {
                if (plateauAffichage[y, x] == "S")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("███");
                }

                else if (plateauAffichage[y, x] == "T")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("███");
                }

                else if (plateauAffichage[y, x] == "A")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("███");
                }

                else
                {
                    Console.ResetColor();
                    Console.Write(plateauAffichage[y,x]);
                }
            }
            Console.WriteLine();
        }
    }

}