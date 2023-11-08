using Godot;
using System;

public partial class cannonBarrel : Sprite2D
{

	bulletBrain bulletBrain;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletBrain = (bulletBrain)GetNode("/root/game/bullets/bulletBrain");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());
	}

    public override void _Input(InputEvent _inputEvent)
    {
		if(_inputEvent.IsActionPressed("click"))
        {
			bulletBrain.spawnBullet(GlobalPosition, GetGlobalMousePosition(), "player");
    	}
	}
}
