Console.OutputEncoding = System.Text.Encoding.UTF8;
        Monde monde = new Monde();

        monde.Planter(2, 1, "🧄");
        monde.Planter(4, 3, "🧅");

        bool jeuActif = true;

        while (jeuActif)
        {
            Console.Clear();
            monde.AfficherMonde();

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                jeuActif = false; // ← quitte la boucle proprement
            }
            else
            {
                monde.BougerJoueur(key);
            }
        }

        Console.Clear();
        Console.WriteLine("👋 Merci d’avoir joué !");