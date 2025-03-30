//
// DungeonRoom.cs
//
// Copyright © 2024 Adam Cvikl
//

internal enum DungeonRoom {
    Empty,
    Spider,
    Skeleton,
    Dragon,
    GoldenSpider,
}




internal static class DungeonRoomExtension {
    internal static DungeonRoom[] GenerateRooms() {
        const int count = 100;

        var rooms = new DungeonRoom[count];
        var random = new Random();

        for (var i = 0; i < count; i++) {
            var seed = random.Next(0, 11);
            rooms[i] = GenerateDungeonRoom(seed);
        }

        return rooms;
    }

  private static DungeonRoom GenerateDungeonRoom(int seed) => seed switch {
        // 0..3
        >= 0 and <= 1 => DungeonRoom.Empty,
        // 4..6
        >= 2 and <= 4 => DungeonRoom.Spider,
        // 7..9
        >= 5 and <= 7 => DungeonRoom.Skeleton,
        >= 8 and <= 9 => DungeonRoom.Dragon,
        10 => DungeonRoom.GoldenSpider,

        _ => throw new InvalidOperationException("Bad dungeon generation probability int"),
    };
}
