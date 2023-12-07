using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    private int Speed { get; set; }
    [Export]
    AnimatedSprite2D Animation { get; set; }

    public override void _Process(double delta)
    {
        GetInput();
        SetAnimation();
        MoveAndSlide();
    }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
    }

    public void SetAnimation()
    {
        
        if (Velocity.X != 0)
        {
            Animation.FlipH = Velocity.X < 0;
        }

        if (Velocity.X == 0 & Velocity.Y == 0)
        {
            Animation.Animation = "Idle";
        } else {
            Animation.Animation = "Run";
        }
    }
}
