using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public partial class EnemyBase : Node2D
{
    [Export]
    public EnemyShot attackPattern;
    [Export] public PackedScene bulletSceneInstance;
    private int shootTimer = 0;
    [Export] public int shotSpeed;
    private float shotDirection = 0;
    [Export] public float diameter = 16;
    private List<BulletUpgrade> bulletUpgrades = new List<BulletUpgrade>();
    [Export] public float spriteAngle = 45;
    [Export] float bulletSpeed;
    [Export] public int hp;

    public override void _Process(double delta)
    {
        shootVoid();
    }

    private void shootVoid()
    {
        shootTimer += 1;
        if (shootTimer % shotSpeed != 0)
        {
            if (shootTimer > 1000) { shootTimer = 0; }
            return;
        }
        foreach (Vector2 vector in attackPattern.shotStyle())
        {
            var bulletNode = (Area2D)bulletSceneInstance.Instantiate() as Bullet;
            BulletDirection(vector, bulletNode);

        }
    }

    private void BulletDirection(Vector2 vector, Bullet bullet)
    {
        if (bullet is not Bullet bulletSceneInstance)
        {
            GD.PrintErr("Bullet instance not set correctly");
            return;
        }

        bullet.speed = bulletSpeed;
        bullet.GlobalPosition = GlobalPosition + vector * diameter;
        float angleRadians = vector.Angle();
        float angleDegrees = angleRadians * (float)(180 / Math.PI);
        bullet.direction = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians)); // Proper direction setting
        bullet.RotationDegrees = angleDegrees + spriteAngle; // Rotate sprite
        GetTree().CurrentScene.AddChild(bullet);
        if (bulletUpgrades.Any())
        {
            foreach (BulletUpgrade upgrade in bulletUpgrades)
            {
                upgrade.ApplyUpgrade(bullet);
            }
        }
        bullet.sprite.Texture = bullet.spriteControl.BulletSpriteColor(bullet);


    }
}
