Console.OutputEncoding = System.Text.Encoding.UTF8;
Monde monde = new Monde();
bool enCours = true;

while (enCours)
{
    Console.Clear();
    monde.AfficherMonde();

    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Escape)
    {
        enCours = false;
    }
    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
    {
        monde.BougerJoueur(key); // pas de passage de jour
    }
    else
    {
        // Actions qui consomment un jour
        switch (key)
        {
            case ConsoleKey.P:
                monde.AfficherMenuPlantesEtPlanter();
                monde.AvancerUnJour();
                break;

            case ConsoleKey.A:
                monde.ArroserCaseSelectionnee();
                monde.AvancerUnJour();
                break;

            case ConsoleKey.C:
                monde.ChasserAraignee();
                monde.AvancerUnJour();
                break;

            default:
                // touche non reconnue
                break;
        }
    }
}
