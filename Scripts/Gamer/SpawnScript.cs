using Godot;
using System;

public partial class SpawnScript : Marker2D
{
	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("/root/Player");
		player.Position = Position;
		player.allowShooting = true;
		GD.Print(player.allowShooting);
		GetNode<CameraFollow>("/root/Camera").Position = Position + new Vector2(576, 0);
		GlobalVars.allowMoving = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
