using Godot;
using System;

public partial class cannonBarrel : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent _inputEvent)
    {
		if(_inputEvent.IsActionPressed("click"))
        {
			GD.Print("left mouse pressed!");
    	}
	}
}
