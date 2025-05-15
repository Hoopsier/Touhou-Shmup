using Godot;
using System;

public partial class Bullet : Area2D
{
	public float speed = 10; // Bullet speed
	[Export] public Sprite2D sprite;
	public Vector2 direction = Vector2.Zero; // Default direction
	public double maxDistance = 20;
	[Export] public BulletSpriteControl spriteControl;
	private double distance = 0;
	public float damage = 1;
	public override void _Ready()
	{
		maxDistance = maxDistance / speed;
	}
	public override void _Process(double delta)
	{
		Position += direction * speed;
		distance += delta;
		if (distance >= maxDistance)
		{
			QueueFree();
		}
	}
	public void hit(Node2D node)
	{
	}
}
