using Godot;
using System;

public partial class bulletBrain : Node
{
	scenes scenes = new scenes();
	Timer enemySpawner;
	[Export] public float maxSpawnInterval = 4.0f;
	[Export] public float minSpawnInterval = 0.5f;
	[Export] public float spawnIntervalDecrease = 0.2f;
	public float spawnInterval = 0.0f;

	[Export] public int playerBulletSpeed = 300;
	[Export] public int enemyBulletSpeed = 250;
	

	// Called when the node enters the scene tree for the first time.;
	public override void _Ready()
	{
		enemySpawner = (Timer)GetNode("enemySpawner");
		spawnInterval = maxSpawnInterval;
		enemySpawner.WaitTime = spawnInterval;
	}

	public void increaseDifficulty()
	{
		var newSpawnInterval = spawnInterval - spawnIntervalDecrease;
		newSpawnInterval = Math.Max(newSpawnInterval,minSpawnInterval);
		enemySpawner.WaitTime = newSpawnInterval;
		enemySpawner.Start();
		spawnInterval = newSpawnInterval;
	}

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

		if (animationName == "player")
		{
			bullet.speed = playerBulletSpeed;
		}else if (animationName == "enemy")
		{
			bullet.speed = enemyBulletSpeed;
		}
	}

	public void spawnExplosion(Vector2 spawnPosition, string animationName)
	{
		// spawn explosion at position
		var explosion = (Area2D)scenes._sceneExplosion.Instantiate();
		GetNode("/root/game/bullets").AddChild(explosion);
		explosion.GlobalPosition = spawnPosition;

		// set the explosion animation
		var explosionSprite = (AnimatedSprite2D)explosion.GetNode("AnimatedSprite2D");
		explosionSprite.Play(animationName);
	}
}
