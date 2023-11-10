using Godot;
using System;
using System.Collections;
using System.Linq;

public partial class BasicAbilityController : Node
{
    [Export] 
    PackedScene BasicAbility { get; set; }

    private float Range = 35;

    public override void _Ready()
    {
        Timer AbilityTimer = GetNode<Timer>("AbilityTimer");
        AbilityTimer.Timeout += () => SpawnAbility();
    }

    public void SpawnAbility()
    {
        var playerNode = GetTree().GetFirstNodeInGroup("Player") as Node2D;

        if (playerNode == null)
        {
            return;
        }

        var enemyNodes = GetTree().GetNodesInGroup("Enemy");

        if (enemyNodes.Count == 0)
        {
            return;
        }

        var distanceSorted = from Node2D enemy in enemyNodes
                             let distance = enemy.GlobalPosition.DistanceSquaredTo(playerNode.GlobalPosition)
                             orderby distance
                             select enemy;


        var target = distanceSorted.ToArray()[0];

            var basicAbilityScene = BasicAbility.Instantiate() as Node2D;

            playerNode.GetParent().AddChild(basicAbilityScene);
            basicAbilityScene.GlobalPosition = playerNode.GlobalPosition;

            var targetDirection = target.GlobalPosition - playerNode.GlobalPosition;

            basicAbilityScene.Rotation = targetDirection.Angle();
    }
}
