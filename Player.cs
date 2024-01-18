//
// Player.cs
//
// Copyright © 2024 Adam Cvikl
//

internal sealed class Player(string name, PlayerTrait trait) : IFightable {
    internal string Name { get; init; } = name;
    internal PlayerTrait Trait { get; } = trait;
    internal int Strength => this.Trait switch {
        PlayerTrait.Strong => 4,
        PlayerTrait.Tough => 2,
        PlayerTrait.Agile => 2,
        _ => throw new InvalidOperationException("Invalid player class!"),
    };

    internal int Toughness => this.Trait switch {
        PlayerTrait.Strong => 1,
        PlayerTrait.Tough => 2,
        PlayerTrait.Agile => 1,
        _ => throw new InvalidOperationException("Invalid player class!"),
    };

    internal int Agility => this.Trait switch {
        PlayerTrait.Strong => 1,
        PlayerTrait.Tough => 1,
        PlayerTrait.Agile => 2,
        _ => throw new InvalidOperationException("Invalid player class!"),
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
