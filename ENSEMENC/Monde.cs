    class Monde
    {
        private Case[,] plateau;

        public Monde(int largeur, int hauteur)
        {
            plateau = new Case[hauteur, largeur];

            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    plateau[y, x] = new Case();
                }
            }
        }

        public void ChangerCouleurCase(int x, int y, ConsoleColor couleur)
        {
            plateau[y, x].Couleur = couleur;
        }

        public void AfficherPlateau()
        {
            int hauteur = plateau.GetLength(0);
            int largeur = plateau.GetLength(1);

            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    plateau[y, x].Afficher();
                }
                Console.WriteLine();
            }
        }
    }
