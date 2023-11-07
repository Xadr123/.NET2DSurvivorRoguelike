using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    private int Speed { get; set; }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
    }

    public void SetAnimation()
    {
        AnimatedSprite2D animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
        if (Velocity.X != 0)
        {
            animation.FlipH = Velocity.X < 0;
        }

        if (Velocity.X == 0 & Velocity.Y == 0)
        {
            animation.Animation = "Idle";
        } else {
            animation.Animation = "Run";
        }
    }

    public override void _Process(double delta)
    {
        GetInput();
        MoveAndSlide();
        SetAnimation();
    }
}
