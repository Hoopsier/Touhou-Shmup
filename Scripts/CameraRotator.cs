using Godot;

public partial class CameraRotator : Node
{
	  private Camera2D camera;
	  public ParallaxBackground parallax = null;
	  public static bool up = true;

	  public void activateCamRotator(float rotation)
	  {
			parallaxinator();
			camera = GlobalVars.camera;
			GD.Print(camera);

			if (up)
			{
				  camera.Rotate(rotation);
				  parallax.Rotation = Mathf.DegToRad(rotation);
			}
	  }
	  private void parallaxinator()
	  {
			if (parallax != null)
			{
				  return;
			}
			var targetNode = GetTree().CurrentScene.FindChild("Background");
			GD.Print(targetNode);
	  }
}
