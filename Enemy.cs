//
// Enemy.cs
//
// Copyright © 2024 Adam Cvikl
//

internal abstract class Enemy {
    private protected string Name { get; init; } = "";
    private protected int Health { get; set; }

    private protected int Strength { get; set; }
    private protected int Toughness { get; set; }
    private protected int Agility { get; set; }

    internal void Fight(Player player) {
        while (true) {
            Task.Delay(1000).Wait();

            this.InflictDamage(player.Strength);
            player.TakeDamage(this.Strength);

            if (player.Health <= 0) {
                Console.WriteLine("You died!");
                Environment.Exit(0);
            }

            if (this.Health <= 0) {
                Console.WriteLine($"You defeated {this.Name}!");
                break;
            }
        }
    }

    private void InflictDamage(int damage) {
        var roll = new Random().Next(this.Agility, 3);

        if (roll == 3) {
            Console.WriteLine("Enemy dodged!");
            return;
        }

        var hpLost = damage / this.Toughness;
        this.Health -= hpLost;

        Console.WriteLine($"{this.Name} took {hpLost} damage and has {this.Health} health left!");
    }
}
