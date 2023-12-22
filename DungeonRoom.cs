//
// DungeonRoom.cs
//
// Copyright © 2024 Adam Cvikl
//

internal enum DungeonRoom : int {
    Empty = 0,
    Spider = 1,
    Skeleton = 2,
}

internal static class DungeonRoomExtension {
    internal static DungeonRoom[] GenerateRooms() {
        const int count = 100;

        var rooms = new DungeonRoom[count];
        var random = new Random();

        for (var i = 0; i < count; i++) {
            var size = random.Next(0, 3);
            rooms[i] = (DungeonRoom)size;
        }

        return rooms;
    }
}
