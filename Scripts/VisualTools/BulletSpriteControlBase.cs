using Godot;
using System;

public abstract partial class BulletSpriteControlBase : Resource
{
	[Export] public Texture2D baseTexture;
	public abstract Texture2D BulletSpriteColor(Bullet bullet);
}
