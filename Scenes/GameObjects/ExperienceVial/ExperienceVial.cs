using Godot;
using System;

public partial class ExperienceVial : Node2D
{

    public override void _Ready()
    {
        var pickUpArea = GetNode<Area2D>("Area2D");
        pickUpArea.AreaEntered += (Area2D) => onPickup();
    }

    public void onPickup()
    {
        GameEvents.Instance.EmitExperienceVialCollected(2);
        QueueFree();
    }

}
