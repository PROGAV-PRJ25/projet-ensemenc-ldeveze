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
        plateauAffichage = new string[Hauteur*2+1, Largeur*2+1];
        int maxX = Hauteur*2;
        int maxY = Largeur*2;

        for (int y = 0; y < Hauteur * 2 + 1; y++)
        {
            for (int x = 0; x < Largeur * 2 + 1; x++)
            {
                if (x % 2 != 0 && y % 2 == 0)
                    plateauAffichage[y, x] = "══════════"; // Mur horizontal
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
            {new Case("Sable",0,0," 🟨🟨🟨"), new Case("Terre",1,0," 🟥🟥🟥"), new Case("Argile",2,0," 🟧🟧🟧")},
            {new Case("Terre",0,1," 🟥🟥🟥"), new Case("Argile",1,1," 🟧🍄🟧"), new Case("Sable",2,1," 🟨🟨🟨")},
            {new Case("Argile",0,2," 🟧🟧🟧"), new Case("Sable",1,2," 🟨🟨🟨"), new Case("Sable",2,2," 🟨🟨🟨")},
        };
    }

    public void AfficherPlateau()
    {
        for (int y = 0; y < Hauteur; y++)
        {
            for (int x = 0; x < Largeur; x++)
            {
                plateauAffichage[y*2+1, x*2+1] = plateau[y,x].Image;
            }
        }

        for (int y = 0; y < Hauteur*2+1; y++)
        {
            for (int x = 0; x < Largeur*2+1; x++)
            {
                Console.Write(plateauAffichage[y,x]);
            }
            Console.WriteLine();
        }
    }

}