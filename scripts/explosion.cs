using Godot;
using System;
using System.Collections;

public partial class explosion : Area2D
{

	bulletBrain bulletBrain;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletBrain = (bulletBrain)GetNode("/root/game/bullets/bulletBrain");
	}


	public void _on_explosion_area_entered(Area2D bullet)
	{
		var bulletType = (AnimatedSprite2D)bullet.GetNodeOrNull("AnimatedSprite2D");
		var explosionType = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
		if ((bulletType != null) && (bulletType.Animation == "enemy") && (bullet is bullet))
		{
			bulletBrain.spawnExplosion(bullet.GlobalPosition, "enemy");
			bullet.QueueFree();
		}
	}

	public void _on_animated_sprite_2d_animation_finished() // only works when anim not looping
	{
		QueueFree();
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
