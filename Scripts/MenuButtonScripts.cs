using Godot;

public partial class MenuButtonScripts : Button
{
	  [Export] public AnimatedSprite2D sprite;
	  // Called when the node enters the scene tree for the first time.
	  public override void _Ready()
	  {
			GlobalVars.pathObj.Add("DevLevel", "Scenes/CodeLevel");
			GD.Print($"{GlobalVars.pathObj["DevLevel"]}");
	  }

	  public void Hovered()
	  {
			sprite.Frame = 1;
	  }
	  public void NotHovered() { sprite.Frame = 0; }
	  public void Start()
	  {

			GD.Print($"{GlobalVars.pathPre}{GlobalVars.pathObj["DevLevel"]}{GlobalVars.pathSuf}");
			var filePath = $"{GlobalVars.pathPre}{GlobalVars.pathObj["DevLevel"]}{GlobalVars.pathSuf}";
			GD.Print(filePath);
			GetTree().ChangeSceneToFile(filePath);
	  }
}
