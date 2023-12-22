//
// Player.cs
//
// Copyright © 2024 Adam Cvikl
//

internal sealed class Player(string name, PlayerTrait trait) {
    public string Name { get; } = name;
    public PlayerTrait Trait { get; } = trait;
    public uint Strength => this.Trait switch {
        PlayerTrait.Strong => 2,
        PlayerTrait.Tough => 1,
        PlayerTrait.Agile => 1,
        _ => throw new InvalidOperationException("Invalid player class!"),
    };

    public uint Toughness => this.Trait switch {
        PlayerTrait.Strong => 1,
        PlayerTrait.Tough => 2,
        PlayerTrait.Agile => 1,
        _ => throw new InvalidOperationException("Invalid player class!"),
    };

    public uint Agility => this.Trait switch {
        PlayerTrait.Strong => 1,
        PlayerTrait.Tough => 1,
        PlayerTrait.Agile => 2,
        _ => throw new InvalidOperationException("Invalid player class!"),
    };

    public uint Health { get; private set; } = MaxHealth;
    public static uint MaxHealth { get; } = 100;
}
