using Godot;
using System;

public partial class scenes : Node
{
    public PackedScene _sceneBullet = (PackedScene)GD.Load("res://scenes/bullet.tscn");
    public PackedScene _sceneExplosion = (PackedScene)GD.Load("res://scenes/explosion.tscn");
}
