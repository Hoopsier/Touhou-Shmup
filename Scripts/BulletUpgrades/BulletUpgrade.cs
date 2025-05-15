using Godot;
using System;

public abstract partial class BulletUpgrade : Resource
{
	[Export] public Texture2D texture;
	[Export] public string name;
	[Export] public float strength;
	public abstract void ApplyUpgrade(Bullet bullet);
}
