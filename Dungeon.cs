//
// Dungeon.cs
//
// Copyright © 2024 Adam Cvikl
//

internal sealed class Dungeon(Player player) {
    private DungeonRoom[] Rooms { get; } = DungeonRoomExtension.GenerateRooms();
    private uint LevelIdx { get; set; }
    private DungeonRoom CurrentRoom {
        get {
            if (this.LevelIdx >= this.Rooms.Length) {
                Win();
            }

            return this.Rooms[this.LevelIdx];
        }
    }

    internal void Play() {
        this.Advance();

        while (true) {
            Console.WriteLine("Do you want to continue? (y/n)");

            userInput:
            var input = Console.ReadLine();

            if (input == "y") {
                // continue
            } else if (input == "n") {
                Console.WriteLine("You ran away from the dungeon!");
                Environment.Exit(0);
            } else {
                Console.WriteLine("Invalid input!");
                goto userInput;
            }

            this.Advance();
        }
    }

    private void Advance() {
        this.LevelIdx++;

        switch (this.CurrentRoom) {
            case DungeonRoom.Empty:
                Console.WriteLine("You enter an empty room.");
                break;

            case DungeonRoom.Spider:
                Console.WriteLine("You have encountered a Spider!");
                var spider = new Spider();
                spider.Fight(player);
                break;

            case DungeonRoom.Skeleton:
                Console.WriteLine("You have encountered a Skeleton!");
                var skeleton = new Skeleton();
                skeleton.Fight(player);
                break;
            case DungeonRoom.Dragon:
                Console.WriteLine("You have encountered a Dragon!");
                var dragon = new Dragon();
                dragon.Fight(player);
                break;
            case DungeonRoom.GoldenSpider:
                Console.WriteLine("You have encountered a Golden Spider!");
                var goldenSpider = new GoldenSpider();
                goldenSpider.Fight(player);

                Console.WriteLine("The Golden Spider has been slain!");
                Console.WriteLine("You win!");
                Environment.Exit(0);
                break;
            default:
                throw new InvalidOperationException("Invalid dungeon room!");
        }
    }

    private static void Win() {
        Console.WriteLine("You cleared the whole dungeon");
        Console.WriteLine("You won!");
        Environment.Exit(0);
    }
}
