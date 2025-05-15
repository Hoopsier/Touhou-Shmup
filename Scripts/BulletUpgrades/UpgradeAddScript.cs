using Godot;
using System;

public partial class UpgradeAddScript : Area2D
{
        [Export] public BulletUpgrade bulletUpgrade;
        [Export] public Sprite2D sprite;
        public override void _Ready(){
                sprite.Texture = bulletUpgrade.texture;
        }

        public void AddUpgrade(PhysicsBody2D body)
        {
                if (body is Player player)
                {
                        GD.Print(bulletUpgrade.GetClass());
                        player.bulletUpgrades.Add(bulletUpgrade);
                        QueueFree();
                }

        }
}
