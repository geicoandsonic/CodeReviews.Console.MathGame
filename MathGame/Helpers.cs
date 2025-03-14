using MathGame.Models;
namespace MathGame;

using System.Linq;
internal class Helpers
{
    static List<Game> games = new List<Game>();
    string username = "";
    internal static void ViewScores()
    {
        
        if (games.Count > 0)
        {
            Console.WriteLine("High Scores");
            Console.WriteLine("------------------------------------------------");
            foreach(var game in games.OrderByDescending(x => x.Score).Take(5)) //Take only the best 5 games
            {
                Console.WriteLine($"{game.Date} | Player {game.Username} | Game Mode: {game.Type} | Score: {game.Score}");
            }
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("No games have been played yet. Press any key to return to the main menu.");
            Console.ReadLine();
        }
    }
    internal static void HowDidThePlayerDo(string username, GameType gameMode, int correctAnswers, int totalQuestions)
    {
        if (correctAnswers == totalQuestions)
        {
            Console.WriteLine("Congratulations! You got all the questions correct! Hit any key to continue...");
            Console.ReadLine();
        }
        else if (correctAnswers == 0)
        {
            Console.WriteLine("You got all the questions wrong. Better luck next time! Hit any key to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"You got {correctAnswers} out of {totalQuestions} questions correct. Nice work! Hit any key to continue...");
            Console.ReadLine();
        }
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = correctAnswers,
            Username = username,
            Type = gameMode
        });
    }

    internal static int GetQuestionCount()
    {
        Console.WriteLine("How many questions would you like to answer?");
        var questions = Console.ReadLine();
        int i;
        if (!int.TryParse(questions, out i))
        {
            Console.WriteLine($"You have selected an invalid number of questions, setting to default of 5.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return 5;
        }
        else if (int.Parse(questions) < 1)
        {
            Console.WriteLine($"You have selected an invalid number of questions, setting to default of 5.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return 5;
        }
        else if (int.Parse(questions) > 10)
        {
            Console.WriteLine($"You have selected an invalid number of questions, setting to maximum of 10.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return 10;
        }
        else
        {
            return int.Parse(questions);
        }
    }

    internal static int[] GetWholeNumbers()
    {
        int firstNum = new Random().Next(1, 9);
        int secondNum = new Random().Next(1, 9);

        var result = new int[2];

        while (firstNum % secondNum != 0)
        {
            firstNum = new Random().Next(1, 9);
            secondNum = new Random().Next(1, 9);
        }

        result[0] = firstNum;
        result[1] = secondNum;
        return result;
    }

    internal static string? ValidateIntegerResult(string? answer)
    {
        while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            answer = Console.ReadLine();
        }
        return answer;
    }
    internal static string? ValidateDecimalResult(string? answer)
    {
        while (string.IsNullOrEmpty(answer) || !Decimal.TryParse(answer, out _))
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal.");
            answer = Console.ReadLine();
        }
        return answer;
    }

    internal static string? GetName()
    {
        Console.WriteLine("Please type your name.");
        var username = Console.ReadLine();
        while (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Invalid input. Please enter a valid name.");
            username = Console.ReadLine();
        }
        return username;
    }
}
