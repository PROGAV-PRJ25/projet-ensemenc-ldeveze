class Case
{
    public ConsoleColor Couleur { get; set; }
    public int CoordX {get; set;}
    public int CoordY {get; set;}

    public Case(int coordX, int coordY)
    {
        Couleur = ConsoleColor.White;
        CoordX = coordX;
        CoordY = coordY;
        
    }


    
}