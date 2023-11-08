using Godot;
using System;

public partial class GameEvents : Node
{
     [Signal]
    public delegate void ExperienceVialCollectedEventHandler(float number);

    public static GameEvents Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }
    public void EmitExperienceVialCollected(float number)
    {
        EmitSignal(SignalName.ExperienceVialCollected, number);
    }
}
