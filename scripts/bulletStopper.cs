using Godot;
using System;

public partial class bulletStopper : Area2D
{
	bulletBrain bulletBrain;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletBrain = (bulletBrain)GetNode("/root/game/bullets/bulletBrain");
	}

	public void _on_bulletStopper_area_entered(Area2D bullet)
	{
		var bulletType = (AnimatedSprite2D)bullet.GetNodeOrNull("AnimatedSprite2D");
		GD.Print("entered : ", bulletType);
		if ((bulletType != null) && (bulletType.Animation == "player") && (bullet is bullet))
		{
			bulletBrain.spawnExplosion(GlobalPosition, "player");

			bullet.QueueFree();
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
