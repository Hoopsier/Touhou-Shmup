using Godot;

public partial class BulletSpriteControl : BulletSpriteControlBase
{
    [Export]
    public Texture2D[] textures;
    public override Texture2D BulletSpriteColor(Bullet bullet)
    {
        return bullet.damage switch
        {
            1 => baseTexture,
            _ => textures[0],
        };
    }

}
