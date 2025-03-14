namespace MathGame;

internal class Menu
{
    
    internal void ShowMenu(string? username, DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello, {username}! Today it is {date}. Ready for a Math Game? Hit any key to begin!");
        Console.ReadLine();
        Console.WriteLine("\n");
        GameEngine gameEngine = new(username);
        var isGameOn = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@$"Please select which game you would like below.
        V - View high scores
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Divison
        Q - Quit the Application");
            Console.WriteLine("-----------------------------------");
            var gameChoice = Console.ReadLine();
            if (gameChoice != null)
            {
                gameChoice = gameChoice.Trim();
                gameChoice = gameChoice.ToUpper();
            }
            else
            {
                gameChoice = "";
            }

            switch (gameChoice)
            {
                case "V":
                    Helpers.ViewScores();
                    break;
                case "A":
                    gameEngine.AdditionGame();
                    break;
                case "S":
                    gameEngine.SubtractionGame();
                    break;
                case "M":
                    gameEngine.MultiplicationGame();
                    break;
                case "D":
                    gameEngine.DivisionGame();
                    break;
                case "Q":
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option. Press any key to continue.");
                    Console.ReadLine();
                    break;
            }
        }
        while (isGameOn);
    }

}
