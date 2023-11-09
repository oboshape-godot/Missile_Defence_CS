using Godot;
using System;

public partial class player : Node
{
	bulletBrain bulletBrain;

	public bool canShoot = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletBrain = (bulletBrain)GetNode("/root/game/bullets/bulletBrain");
		updateUI();
	}

	public void _on_playerHitZone_area_entered(Area2D bullet)
	{
		var bulletType = (AnimatedSprite2D)bullet.GetNodeOrNull("AnimatedSprite2D");
		if ((bulletType != null) && (bulletType.Animation == "enemy") && (bullet is bullet))
		{
			bulletBrain.spawnExplosion(bullet.GlobalPosition, "enemy");
			bullet.QueueFree();
		}
	}

	public void updateUI()
	{
		var healthAndScore = (Label)GetNode("/root/game/hud/healthAndScore");
		healthAndScore.Text = "Hey This Works!";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
