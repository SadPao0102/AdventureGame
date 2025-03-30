//
// Player.cs
//
// Copyright © 2024 Adam Cvikl
//

internal sealed class Player(string name, PlayerTrait trait) : IFightable {
    internal string Name { get; init; } = name;
    internal PlayerTrait Trait { get; } = trait;
    internal int Strength => this.Trait switch {
        PlayerTrait.Strong => 5,
        PlayerTrait.Tough => 3,
        PlayerTrait.Agile => 3,
        _ => throw new InvalidOperationException("Invalid player trait!"),
    };

    internal int Toughness => this.Trait switch {
        PlayerTrait.Strong => 3,
        PlayerTrait.Tough => 5,
        PlayerTrait.Agile => 3,
        _ => throw new InvalidOperationException("Invalid player trait!"),
    };

    internal int Agility => this.Trait switch {
        PlayerTrait.Strong => 2,
        PlayerTrait.Tough => 2,
        PlayerTrait.Agile => 4,
        _ => throw new InvalidOperationException("Invalid player trait!"),
    };

    internal int Health { get; private set; } = MaxHealth;
    private static int MaxHealth { get; } = 100;

    internal void TakeDamage(int damage) {
        var roll = new Random().Next(this.Agility, 4);

        if (roll == 3) {
            Console.WriteLine("You dodged!");
            return;
        }

        var hpLost = damage / this.Toughness;
        this.Health -= hpLost;

        Console.WriteLine($"You took {hpLost} damage and you have {this.Health} health left!");
    }
}
