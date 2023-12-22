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
        while (true) {
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
                Console.WriteLine("You have encountered a spider!");
                var spider = new Spider();
                spider.Fight(player);
                break;

            case DungeonRoom.Skeleton:
                Console.WriteLine("You have encountered a skeleton!");
                var skeleton = new Skeleton();
                skeleton.Fight(player);
                break;

            default:
                throw new InvalidOperationException("Invalid dungeon room!");
        }
    }

    private static void Win() {
        Console.WriteLine("You won!");
        Environment.Exit(0);
    }
}
