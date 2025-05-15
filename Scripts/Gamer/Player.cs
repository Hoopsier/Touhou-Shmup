using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public partial class Player : CharacterBody2D
{
    [Export] public PackedScene bulletSceneInstance;


    public List<BulletUpgrade> bulletUpgrades = new List<BulletUpgrade>();
    private float worldSpeed = GlobalVars.speed;
    private float xMoveSpeedBase = 75;
    private float xSpd = 0;
    private float ySpd = 0;
    private float ySpdBase = 150;
    private int shootTimer = 0;
    private int shootTimerMax = 15;
    private int shotSpeed1 = 40; //frames until shot
    public bool allowShooting = false;
    private bool leftObstructed = false;
    private bool rightObstructed = false;
    private bool upObstructed = false;
    private bool downObstructed = false;
    private float shotDirection = 0;
    public override void _Ready()
    {
        Position = new Vector2(288, 324);

    }

    public override void _PhysicsProcess(double delta)
    {
        if (!GlobalVars.allowMoving) { return; }
        Velocity = new Vector2(xSpd, ySpd); // Move forward on X
        MoveAndSlide();
    }
    public override void _Process(double delta)
    {
        ySpd = YSpd();
        xSpd = XSpd();
        if (allowShooting) { Shoot(); }

    }
    private float YSpd()
    {
        var result = 0f;
        if (Input.IsActionPressed("up"))
        {
            result -= ySpdBase;
        }
        if (Input.IsActionPressed("down"))
        {

            result += ySpdBase;
        }
        return result;
    }
    private float XSpd() //could be cleaner but I don't really care
    {
        var result = 0f;
        var front = false;
        if (Input.IsActionPressed("left"))
        {
            result -= xMoveSpeedBase;
        }
        if (Input.IsActionPressed("right"))
        {
            result += xMoveSpeedBase;
            front = true;
        }
        if (front) { result /= 1.5f; }
        return result;
    }
    private void Shoot()
    {
        shootTimer += 1;
        if (shootTimer % shotSpeed1 == 0)
        {

            if (bulletSceneInstance == null) return;
            var bulletNode = (Area2D)bulletSceneInstance.Instantiate() as Bullet;
            BulletDirection(shotDirection, bulletNode, 45);

        }
        if (shootTimer > 1000) { shootTimer = 0; }
    }
    private void BulletDirection(float angleDegrees, Bullet bullet, float spriteAngle)
    {
        if (bullet is Bullet bulletSceneInstance)
        {
            bullet.GlobalPosition = GlobalPosition;
            float angleRadians = Mathf.DegToRad(angleDegrees);
            bullet.direction = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians)); // Proper direction setting
            bullet.RotationDegrees = angleDegrees + spriteAngle; // Rotate sprite
            GetTree().CurrentScene.AddChild(bulletSceneInstance);
            if (bulletUpgrades.Any())
            {
                foreach (BulletUpgrade upgrade in bulletUpgrades)
                {
                    upgrade.ApplyUpgrade(bulletSceneInstance);
                }
            }
            bullet.sprite.Texture = bullet.spriteControl.BulletSpriteColor(bullet);
        }
        else
        {
            GD.PrintErr("Bullet instance not set correctly");
        }
    }
}
