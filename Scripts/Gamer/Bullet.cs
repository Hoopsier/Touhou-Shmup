using System;
using Godot;

public partial class Bullet : CharacterBody2D
{
    public float speed = 10; // Bullet speed

    [Export]
    public Sprite2D sprite;
    public Vector2 direction = Vector2.Zero; // Default direction
    public double maxDistance = 20;
    public BulletSpriteControl spriteControl;
    private double distance = 0;
    public float damage = 1;

    public enum Entity
    {
        Player,
        Enemy,
    }

    public Entity target = Entity.Player; // Default to targeting player (enemy targeting is done like once)

    public override void _Ready()
    {
        maxDistance = maxDistance / speed;
        speed *= 100;
        spriteControl = (BulletSpriteControl)GD.Load("res://Resources/BulletSpriteResource.tres");
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += direction * speed * (float)delta;
        distance += delta;
        if (distance >= maxDistance)
        {
            QueueFree();
        }
    }

    public void hit(Node2D node)
    {
        switch (target)
        {
            case Entity.Player:
                if (!node.IsInGroup("Player"))
                    break;
                if (node is Player player)
                {
                    player.gotHit();
                    QueueFree();
                }
                break;
            case Entity.Enemy:
                if (!node.IsInGroup("Enemy"))
                    break;
                if (node is EnemyBase enemy)
                {
                    enemy.gotHit(damage);
                    QueueFree();
                }
                break;
        }
    }
}
