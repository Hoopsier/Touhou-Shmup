using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Godot;

public partial class EnemyBase : Node2D
{
    [Export]
    public EnemyShot attackPattern;

    [Export]
    public PackedScene bulletSceneInstance;
    private int shootTimer = 0;

    [Export]
    public int shotSpeed;
    private float shotDirection = 0;

    [Export]
    public float diameter = 16;

    [Export]
    public float spriteAngle = 45;

    [Export]
    float bulletSpeed;

    [Export]
    public int hp = 10;

    public override void _Process(double delta)
    {
        shootVoid();
    }

    private void shootVoid()
    {
        shootTimer += 1;
        if (shootTimer % shotSpeed != 0)
        {
            if (shootTimer > 1000)
            {
                shootTimer = 0;
            }
            return;
        }
        foreach (Vector2 vector in attackPattern.shotStyle())
        {
            var bulletNode = (CharacterBody2D)bulletSceneInstance.Instantiate() as Bullet;
            if (bulletNode is Bullet bullet)
            {
                BulletDirection(vector, bullet);
            }
        }
    }

    private void BulletDirection(Vector2 vector, Bullet bullet)
    {
        bullet.speed = bulletSpeed;
        bullet.GlobalPosition = GlobalPosition + vector * diameter;
        float angleRadians = vector.Angle();
        float angleDegrees = angleRadians * (float)(180 / Math.PI);
        bullet.direction = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians)); // Proper direction setting
        bullet.RotationDegrees = angleDegrees + spriteAngle; // Rotate sprite
        GetTree().CurrentScene.AddChild(bullet);
    }

    public void gotHit(float damage)
    {
        hp -= (int)Math.Round(damage);
        GD.Print($"enemy {hp}");
        if (hp <= 0)
        {
            // Handle enemy death (e.g., play death animation, spawn particles, etc.)
            // Example: EmitSignal(SignalName.EnemyDefeated, 10); // Signal with score value
            // PlayDeathAnimation();
            QueueFree(); // Remove the enemy from the scene
        }
    }
}
