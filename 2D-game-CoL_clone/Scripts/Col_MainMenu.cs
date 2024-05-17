using Godot;
using System;
using System.Diagnostics;

public partial class Col_MainMenu : Node2D
{
    public void startGame()
    {
        Debug.WriteLine("Inside Button");
        var scene = GD.Load<PackedScene>("res://2D-Game-CoL_clone/CoLGameDemo.tscn");
        GetTree().ChangeSceneToPacked(scene);
    }
}
