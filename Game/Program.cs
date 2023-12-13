// See https://aka.ms/new-console-template for more information
using Game;

Console.WriteLine("Welcome!");
Console.WriteLine("");
Console.WriteLine("Would you like to play a game or simulate statistics?");
Console.Write("[P]lay/[S]imulate: ");

var choice = ChooseAndValidate();
if (choice.ToLower() == "p")
{
    Console.WriteLine("You have choosed to play a game.");

    var initBallGameplay = new InitBallGamplay(5, 14, new Ball(), 1);
    var player = new Player(100);

    var balls = initBallGameplay.SetBalls();
    var ballGame = new BallGame(balls);

    ballGame.NewSession(player);
}

if (choice.ToLower() == "s")
{
    Console.WriteLine("You have choosed to simulate statistics");
    //instantiate bilogger
}


static string ChooseAndValidate()
{
    var choice = Console.ReadLine();

    if (String.IsNullOrEmpty(choice) || (choice.ToLower() != "p" && choice.ToLower() != "s"))
    {
        Console.WriteLine("Sorry, cannot recognize the option, please try again");
        choice = ChooseAndValidate();
    }

    return choice;
}

