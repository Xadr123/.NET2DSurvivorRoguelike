using Godot;
using System;

public partial class GameTimeUI : CanvasLayer
{
	[Export]
	public Node GameTimeController { get; set; }

	public Label GameTime;

	public override void _Ready()
	{
		GameTime = GetNode<Label>("%Label");
	}

	public string timerFormat(float seconds)
	{
		var minutes = Mathf.Floor(seconds / 60);
		var secondsLeft = seconds - (minutes * 60);
		return minutes + ":" + Mathf.Floor(secondsLeft).ToString("00");
	}

	public override void _Process(double delta)
	{
		if (GameTimeController == null)
		{
			return;
		}
		var timerNode = GameTimeController.GetNode<Timer>("GameTimer");
		var timeElapsed = timerNode.WaitTime - timerNode.TimeLeft;
		GameTime.Text = timerFormat((float)timeElapsed);
	}
}
