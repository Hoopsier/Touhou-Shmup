using Godot;
using System;

public partial class AutoMovingParallax : ParallaxBackground
{
	  [Export] public Vector2 speed = new Vector2(50, 0);
	  // Called when the node enters the scene tree for the first time.
	  public override void _Ready()
	  {
	  }

	  // Called every frame. 'delta' is the elapsed time since the previous frame.
	  public override void _Process(double delta)
	  {

			ScrollBaseOffset -= speed * (float)delta;

	  }
}
