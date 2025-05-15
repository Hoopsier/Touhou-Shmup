using Godot;
using System;

public partial class PathFollow2d : PathFollow2D
{
    [Export]
    public float speed = 5f;
    public override void _Process(double delta)
    {
        this.Progress += speed;
    }
}
