using Godot;
using System;

public partial class bulletStopper : Area2D
{
	bulletBrain bulletBrain;
	player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletBrain = (bulletBrain)GetNode("/root/game/bullets/bulletBrain");
		player = (player)GetNode("/root/game/player");
	}

	public void _on_bulletStopper_area_entered(Area2D bullet)
	{
		var bulletType = (AnimatedSprite2D)bullet.GetNodeOrNull("AnimatedSprite2D");
		if ((bulletType != null) && (bulletType.Animation == "player") && (bullet is bullet))
		{
			//bulletBrain.spawnExplosion(GlobalPosition, "player");
			bulletBrain.CallDeferred("spawnExplosion", GlobalPosition, "player");

			bullet.QueueFree();
			QueueFree(); // destroys bulletstopper

			player.canShoot = true;
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
