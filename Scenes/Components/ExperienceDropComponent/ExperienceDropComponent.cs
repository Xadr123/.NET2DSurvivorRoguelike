using Godot;
using System;

public partial class ExperienceDropComponent : Node
{
    [Export]
    Node HealthComponent;
    [Export]
    PackedScene ExperienceVial;

    public override void _Ready()
    {
        (HealthComponent as HealthComponent).Died += OnDeath;
    }

    public void OnDeath()
    {
        if (ExperienceVial == null)
        {
            return;
        }

        if (Owner is not Node2D)
        {
            return;
        }

        var spawnPosition = (Owner as Node2D).GlobalPosition;
        var expVial = ExperienceVial.Instantiate() as Node2D;

        Owner.GetParent().AddChild(expVial);
        expVial.GlobalPosition = spawnPosition;
    }
}
