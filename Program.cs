//
// Program.cs
//
// Copyright © 2024 Adam Cvikl
//

Console.WriteLine("Welcome to the game!");
Console.WriteLine("What is your name?");

var name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name)) {
    Console.WriteLine("Invalid name!");
    Environment.Exit(1);
}

Console.WriteLine("Please select your trait:");
Console.WriteLine("1. Strong (stronger attacks)");
Console.WriteLine("2. Tough (more health)");
Console.WriteLine("3. Agile (more dodges)");

int traitChoice;
var isValidChoice = false;

do {
    Console.Write("Enter your choice (1-3): ");
    var input = Console.ReadLine();

    isValidChoice = int.TryParse(input, out traitChoice) && traitChoice >= 1 && traitChoice <= 3;

    if (!isValidChoice) {
        Console.WriteLine("Invalid choice! Please try again.");
    }
} while (!isValidChoice);

var playerTrait = traitChoice switch {
    1 => PlayerTrait.Strong,
    2 => PlayerTrait.Tough,
    3 => PlayerTrait.Agile,
    _ => throw new InvalidOperationException("Invalid player trait!"),
};

var player = new Player(name, playerTrait);

Console.WriteLine($"Welcome, {player.Name}, the {player.Trait}!");

var dungeon = new Dungeon(player);
dungeon.Play();
