using Godot;
using System;

public partial class EnemyController : Node
{
    [Export]
    public PackedScene BabyGoblin;

    private int Radius = 300;

    public override void _Ready()
	{
		var spawnTimer = GetNode<Timer>("Timer");
		spawnTimer.Timeout += spawnEnemy;
	}
	public void spawnEnemy()
	{
		var playerNode = GetTree().GetFirstNodeInGroup("Player") as Node2D;
        
		if (playerNode == null)
		{
			return;
		}

		var randomDirection = Vector2.Right.Rotated((float)GD.RandRange(0, Mathf.Pi));
		var spawnPosition = playerNode.GlobalPosition + (randomDirection * Radius);
		var babyGoblin = BabyGoblin.Instantiate() as Node2D;

		babyGoblin.GlobalPosition = spawnPosition;
		GetParent().AddChild(babyGoblin);
	}
}
