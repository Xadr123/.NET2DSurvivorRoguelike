using Godot;
using System;

public partial class GameCamera : Camera2D
{
    public override void _Ready()
    {
        MakeCurrent();
    }

    public override void _Process(double delta)
    {
        var playerNode = GetTree().GetFirstNodeInGroup("Player") as Node2D;

        if (playerNode == null)
        {
            return;
        }
        
        GlobalPosition = playerNode.GlobalPosition;
    }
}
