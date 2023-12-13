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

    var player = new Player(100);

    var initBallGameplay = new InitBallGamplay(5, 14, new Ball(), 1);
    var balls = initBallGameplay.SetBalls();
    var ballGame = new BallGame(balls);

    ballGame.NewSession(player);
}

if (choice.ToLower() == "s")
{
    Console.WriteLine("You have choosed to simulate statistics");

    var initBallGameplay = new InitBallGamplay(5, 14, new Ball(), 1);
    var balls = initBallGameplay.SetBalls();
    var ballGame = new BallGame(balls);

    var logger = new BILogger();
    while (true)
    {
        Console.Write("How many rounds of simulation you want to perform?: ");
        var amount = ValidateSimulationRounds();
        logger.SimulateGame(ballGame, amount);

        Console.WriteLine("Would you like to simulate again?");
        Console.Write("[Y]/[N]: ");
        var response = ValidateInput(Console.ReadLine());
        if (response.ToLower() == "n")
        {
            break;
        }
    }
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

static int ValidateSimulationRounds()
{
    try
    {
        var noOfSimulations = int.Parse(Console.ReadLine());
        return noOfSimulations;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Invalid number. Please try again");
        Console.WriteLine("You tried to the following: " + ex.Message);
        Console.Write("How many rounds of simulation you want to perform?: ");
        return ValidateSimulationRounds();
    }
}

static string ValidateInput(string input)
{

    if (String.IsNullOrEmpty(input) || (input.ToLower() != "y" && input.ToLower() != "n"))
    {
        Console.WriteLine("Sorry, cannot recognize the input, please try again");
        Console.Write("[Y]/[N]: ");
        input = ValidateInput(Console.ReadLine());
    }

    return input;
}

