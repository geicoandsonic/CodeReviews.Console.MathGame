namespace MathGame.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public string Username { get; set; }
    public GameType Type { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Whole_Number_Division,
    Decimal_Division
}
