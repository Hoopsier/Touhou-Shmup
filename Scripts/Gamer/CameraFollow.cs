using Godot;
using System;

public partial class CameraFollow : CharacterBody2D
{
	  private float time = 0f;
	  private Player player;
	  private Vector2 camPos;
	  public bool swayDir = true; // false disables, true up and down

	  // Called when the node enters the scene tree for the first time.
	  public override void _Ready()
	  {
			player = GetNode<Player>("/root/Player");
			Position = new Vector2(0, DisplayServer.ScreenGetSize().Y / 5 * 3);
			camPos = Position;
	  }

	  public override void _Process(double delta)
	  {
			Position = new Vector2(Position.X, camPos.Y + SwingCam(delta));
	  }

	  public float SwingCam(double delta)
	  {
			time += (float)delta;
			var swingSpeed = 1;
			var swingPeak = 100;

			return swayDir ? swingPeak * MathF.Sin(swingSpeed * time)
			: swingPeak * MathF.Sin(swingSpeed * time + MathF.PI / 2);
	  }
}
