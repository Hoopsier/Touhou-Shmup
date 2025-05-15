using Godot;
using System;

[GlobalClass] // Makes it selectable in the Godot Editor
public partial class BulletDamageUp : BulletUpgrade
{
	public override void ApplyUpgrade(Bullet bullet)
	{
		bullet.damage *= strength;
	}
}
