// Dragon.cs
using System;

internal sealed class Dragon : Enemy {
    internal Dragon() {
        this.Name = "Dragon";
        this.Health = 15; // กำหนดพลังชีวิตของมังกร
        this.Strength = 10; // กำหนดความแข็งแกร่ง
        this.Toughness = 5; // กำหนดความทนทาน
        this.Agility = 2; // กำหนดความคล่องตัว
    }
}
