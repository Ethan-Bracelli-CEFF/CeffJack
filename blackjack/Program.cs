using blackjack;

class Program
{
    static void Main(string[] args)
    {
        int width = Console.LargestWindowWidth / 2 + Console.LargestWindowWidth / 4; // Ajuste à la moitié de la largeur maximale
        int height = Console.LargestWindowHeight / 2; // Ajuste à la moitié de la hauteur maximale

        Console.SetBufferSize(width, height);
        Console.SetWindowSize(width, height);

        Draw draw = new Draw();
        draw.DrawTitle();
        Console.WriteLine("Bienvenu au CeffJack!");
        Console.Write("Entrez le nom des joueurs (séparé d'une virgule): ");
        string input = Console.ReadLine();
        List<string> playerNames = input.Split(',').Select(name => name.Trim()).ToList();

        Game game = new Game(playerNames);
        game.StartGame();
    }
}
