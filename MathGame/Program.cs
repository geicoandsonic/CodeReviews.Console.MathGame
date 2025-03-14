using MathGame;

var menu = new Menu();

var date = DateTime.UtcNow;

string? username = Helpers.GetName();

menu.ShowMenu(username,date);
