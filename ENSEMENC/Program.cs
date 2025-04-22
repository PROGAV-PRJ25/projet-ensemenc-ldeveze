Monde monde = new Monde(5, 5); // Plateau 5x5

// Modifier quelques couleurs
monde.ChangerCouleurCase(2, 2, ConsoleColor.Red);
monde.ChangerCouleurCase(1, 0, ConsoleColor.Yellow);
monde.ChangerCouleurCase(4, 4, ConsoleColor.Green);

monde.AfficherPlateau();

Console.ReadKey();