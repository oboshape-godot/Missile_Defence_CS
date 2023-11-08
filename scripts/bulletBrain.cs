using Godot;
using System;

public partial class bulletBrain : Node
{
	scenes scenes = new scenes();
	

	public void _on_enemy_spawner_timeout()
	{
		spawnEnemy();
	}

	public void spawnEnemy()
	{
		Vector2 spawnPosition = new Vector2(Convert.ToSingle(GD.RandRange(0,1000)), -30.0f);
		Vector2 targetPosition = new Vector2(Convert.ToSingle(GD.RandRange(0,1000)), 550.0f);

		spawnBullet(spawnPosition,targetPosition,"enemy");
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void spawnBullet(Vector2 spawnPosition, Vector2 targetPosition, string animationName)
	{
		// spawn bullet at position, and look at target position
		var bullet = (bullet)scenes._sceneBullet.Instantiate();
		GetNode("/root/game/bullets").AddChild(bullet);
		bullet.GlobalPosition = spawnPosition;
		bullet.LookAt(targetPosition);

		// set the bullet animation
		var bulletSprite = (AnimatedSprite2D)bullet.GetNode("AnimatedSprite2D");
		bulletSprite.Play(animationName);
	}

	public void spawnExplosion(Vector2 spawnPosition, string animationName)
	{
		// spawn explosion at position
		var explosion = (bullet)scenes._sceneBullet.Instantiate();
		GetNode("/root/game/bullets").AddChild(explosion);
		explosion.GlobalPosition = spawnPosition;

		// set the explosion animation
		var explosionSprite = (AnimatedSprite2D)explosion.GetNode("AnimatedSprite2D");
		explosionSprite.Play(animationName);
	}
}
