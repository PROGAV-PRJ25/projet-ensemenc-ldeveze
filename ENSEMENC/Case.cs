class Case
{
    public ConsoleColor Couleur { get; set; } = ConsoleColor.White;

    public void Afficher()
    {
        Console.ForegroundColor = Couleur;
        Console.Write("█");
        Console.ResetColor();
    }
}