using Godot;
using System;

[GlobalClass] // Makes it selectable in the Godot Editor
public partial class BulletSpeedUp : BulletUpgrade
{
	public override void ApplyUpgrade(Bullet bullet)
	{
		bullet.speed *= strength;
	}
}
