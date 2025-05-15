using Godot;
using System;
using System.Collections.Generic;
[GlobalClass]
public partial class EnemyShotFlower : EnemyShot
{
    [Export] public Texture2D bulletTexture;
    [Export] public int divider = 30;
    public override IEnumerable<Vector2> shotStyle()
    {
        float angle = 360 / divider;
        float radians = angle * (float)(Math.PI / 180);
        Vector2 vector;

        for (var iteration = 0; iteration < divider; iteration++)
        {
            vector = Vector2.FromAngle(radians * iteration);
            yield return vector;
        }
    }
}
