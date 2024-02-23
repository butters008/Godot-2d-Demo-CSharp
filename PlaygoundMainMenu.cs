using Godot;
using System;
using System.Diagnostics;

public partial class PlaygoundMainMenu : Node2D
{
	private string levelName;


	public void _on_button_pressed()
	{
		Debug.WriteLine("Inside Button");
		var scene = GD.Load<PackedScene>("res://2D-game-CoL_clone/Col_MainMenu.tscn");
		GetTree().ChangeSceneToPacked(scene);

	}

	public void platformerButton_pressed()
	{
		Debug.WriteLine("Inside Button");
		var scene = GD.Load<PackedScene>("res://2D-Platformer/GameDemo/2D-Demo-Better.tscn");
		GetTree().ChangeSceneToPacked(scene);
	}
}
