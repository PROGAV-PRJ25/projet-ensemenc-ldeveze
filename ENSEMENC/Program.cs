Console.OutputEncoding = System.Text.Encoding.UTF8;
Monde monde = new Monde();
bool enCours = true;
while (enCours)
{
    Console.Clear();
    monde.AfficherMonde();

    var key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Escape) enCours = false;
    else if (key == ConsoleKey.J) monde.AvancerUnJour();
    else if (key == ConsoleKey.P) monde.AfficherMenuPlantesEtPlanter();
    else monde.BougerJoueur(key);
}