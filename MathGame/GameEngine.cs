using MathGame.Models;

namespace MathGame;

internal class GameEngine
{
    string username = "";
    internal GameEngine(string user)
    {
        username = user;
    }
    internal void AdditionGame()
    {
        int questionCount = Helpers.GetQuestionCount();

        int firstNum, secondNum;
        int correctAnswers = 0;
        for (int i = 0; i < questionCount; i++)
        {
            Console.Clear();
            Console.WriteLine("Addition Game");
            firstNum = new Random().Next(1, 9);
            secondNum = new Random().Next(1, 9);

            Console.WriteLine($"What is {firstNum} + {secondNum}?");
            var answer = Console.ReadLine();
            answer = Helpers.ValidateIntegerResult(answer);
            if (int.Parse(answer) == firstNum + secondNum)
            {
                Console.WriteLine("Correct! Hit any key to continue...");
                correctAnswers++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {firstNum + secondNum}. Hit any key to continue...");
                Console.ReadLine();
            }
        }
        Helpers.HowDidThePlayerDo(username,GameType.Addition, correctAnswers, questionCount);
    }

    internal void SubtractionGame()
    {
        int questionCount = Helpers.GetQuestionCount();

        int firstNum, secondNum;
        int correctAnswers = 0;
        for (int i = 0; i < questionCount; i++)
        {
            Console.Clear();
            Console.WriteLine("Subtraction Game");
            firstNum = new Random().Next(1, 9);
            secondNum = new Random().Next(1, 9);

            Console.WriteLine($"What is {firstNum} - {secondNum}?");
            var answer = Console.ReadLine();
            answer = Helpers.ValidateIntegerResult(answer);
            if (int.Parse(answer) == firstNum - secondNum)
            {
                Console.WriteLine("Correct! Hit any key to continue...");
                correctAnswers++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {firstNum - secondNum}. Hit any key to continue...");
                Console.ReadLine();
            }
        }
        Helpers.HowDidThePlayerDo(username, GameType.Subtraction, correctAnswers, questionCount);
    }

    internal void MultiplicationGame()
    {
        int questionCount = Helpers.GetQuestionCount();

        int firstNum, secondNum;
        int correctAnswers = 0;
        for (int i = 0; i < questionCount; i++)
        {
            Console.Clear();
            Console.WriteLine("Multiplication Game");
            firstNum = new Random().Next(1, 9);
            secondNum = new Random().Next(1, 9);

            Console.WriteLine($"What is {firstNum} * {secondNum}?");
            var answer = Console.ReadLine();
            answer = Helpers.ValidateIntegerResult(answer);
            if (int.Parse(answer) == firstNum * secondNum)
            {
                Console.WriteLine("Correct! Hit any key to continue...");
                correctAnswers++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {firstNum * secondNum}. Hit any key to continue...");
                Console.ReadLine();
            }
        }
        Helpers.HowDidThePlayerDo(username, GameType.Multiplication, correctAnswers, questionCount);
    }

    internal void DivisionGame()
    {
        Console.WriteLine("Division game selected.");
        Console.WriteLine("Please choose between Whole Number Division (W), Decimal Division (D).");
        var divisionChoice = Console.ReadLine();
        if (divisionChoice != null)
        {
            divisionChoice = divisionChoice.Trim();
            divisionChoice = divisionChoice.ToUpper();
        }
        else
        {
            divisionChoice = "";
        }
        while (divisionChoice != "D" && divisionChoice != "W")
        {
            Console.WriteLine("Invalid choice. Please select a valid option.");
            divisionChoice = Console.ReadLine();
            divisionChoice = divisionChoice.Trim().ToUpper();
        }
        switch (divisionChoice)
        {
            case "W":
                WholeNumberDivision();
                break;
            case "D":
                DecimalDivision();
                break;
            default:
                WholeNumberDivision();
                break;
        }
    }

    internal void WholeNumberDivision()
    {
        int questionCount = Helpers.GetQuestionCount();
        int correctAnswers = 0;
        for (int i = 0; i < questionCount; i++)
        {
            Console.Clear();
            Console.WriteLine("Whole Number Division Game");
            int[] values = Helpers.GetWholeNumbers();
            Console.WriteLine($"What is {values[0]} / {values[1]}?");
            var answer = Console.ReadLine();
            answer = Helpers.ValidateIntegerResult(answer);
            if (int.Parse(answer) == values[0] / values[1])
            {
                Console.WriteLine("Correct! Hit any key to continue...");
                correctAnswers++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {values[0] / values[1]}. Hit any key to continue...");
                Console.ReadLine();
            }
        }
        Helpers.HowDidThePlayerDo(username, GameType.Whole_Number_Division, correctAnswers, questionCount);
    }
    internal void DecimalDivision()
    {
        int questionCount = Helpers.GetQuestionCount();
        int firstNum, secondNum;
        int correctAnswers = 0;
        for (int i = 0; i < questionCount; i++)
        {
            Console.Clear();
            Console.WriteLine("Decimal Division Game");
            firstNum = new Random().Next(1, 9);
            secondNum = new Random().Next(1, 9);

            Console.WriteLine($"What is {firstNum} / {secondNum} (up to 2 decimal places)?");
            var answer = Console.ReadLine();
            answer = Helpers.ValidateDecimalResult(answer);
            if (Decimal.Parse(answer) == Math.Round((decimal)firstNum / (decimal)secondNum, 2))
            {
                Console.WriteLine("Correct! Hit any key to continue...");
                correctAnswers++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {Math.Round((decimal)firstNum / (decimal)secondNum, 2)}. Hit any key to continue...");
                Console.ReadLine();
            }
        }
        Helpers.HowDidThePlayerDo(username, GameType.Decimal_Division, correctAnswers, questionCount);
    }
}
