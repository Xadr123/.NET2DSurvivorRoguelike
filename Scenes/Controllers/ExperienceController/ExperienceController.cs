using Godot;
using System;
using System.ComponentModel;

public partial class ExperienceController : Node
{
    public float currentExperience;

    public override void _Ready()
    {
        GameEvents.Instance.Connect(GameEvents.SignalName.ExperienceVialCollected, Callable.From<float>(OnExperienceCollected));
    }

    public void IncrementExperience(float number)
    {
        currentExperience += number;
    }

    public void OnExperienceCollected(float number)
    {
        IncrementExperience(1);
        GD.Print(currentExperience);
    }
}
