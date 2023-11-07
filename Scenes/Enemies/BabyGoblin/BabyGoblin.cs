using Godot;
using System;

public partial class BabyGoblin : CharacterBody2D
{
    [Export]
    private int Speed { get; set; }

    public override void _Ready()
    {
        Area2D hitBox = GetNode<Area2D>("Area2D");

        hitBox.AreaEntered += OnHit;
    }

   	public void GetPlayerDirection()
	{
		var playerNode = GetTree().GetFirstNodeInGroup("Player") as Node2D;
        var playerDirection = (playerNode.GlobalPosition - GlobalPosition).Normalized();
		
        if (playerNode == null)
		{
            return;
		}
		
        Velocity = playerDirection * Speed;
	}

	public void FlipAnimation()
    {
        AnimatedSprite2D animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
        if (Velocity.X != 0)
        {
            animation.FlipH = Velocity.X < 0;
        }
    }

    public override void _Process(double delta)
    {
        GetPlayerDirection();
        MoveAndSlide();
        FlipAnimation();
    }
    
    public void OnHit(Area2D area)
    {
        QueueFree();
    }
}
