using Godot;
using System;

public partial class bullet : Area2D
{
	public int speed = 400;
	Vector2 velocity = new Vector2(0f,0f);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		velocity = Vector2.Right.Rotated(Rotation) * speed * (float)_delta;
		Translate(velocity);
	}
}
