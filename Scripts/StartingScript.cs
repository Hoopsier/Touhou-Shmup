using System.Collections.Generic;
using Godot;

[Tool]
public partial class GlobalVars : Node
{
	public const float baseSpeed = 5.0f;
	public static float speed = baseSpeed;
	public static GlobalVars Instance { get; private set; }
	public static string pathPre { get; set; } = "res://";
	public static string pathSuf { get; set; } = ".tscn";
	public static Dictionary<string, string> pathObj { get; set; } = new Dictionary<string, string>();
	public static Player player;
	public static Camera2D camera;
	public static bool allowMoving = false;

	public override void _Ready()
	{
		player = GetNode<Player>("/root/Player");
		camera = GetNode<Camera2D>("/root/Camera");
		Instance = this;
	}
}
