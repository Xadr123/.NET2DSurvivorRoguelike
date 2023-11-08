using Godot;
using System;

[GlobalClass]
public partial class HealthComponent : Node
{
    [Signal]
    public delegate void DiedEventHandler();
    [Export]
    public float MaxHealth = 10;

    public float CurrentHealth;

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void DealDamage(float damage)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);

        if (CurrentHealth == 0)
        {
            EmitSignal(SignalName.Died);
            Owner.QueueFree();
        }
    }
}
