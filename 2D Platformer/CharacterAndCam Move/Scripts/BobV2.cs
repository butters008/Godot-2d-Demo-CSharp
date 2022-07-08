using Godot;
using System;

public class BobV2 : KinematicBody2D
{
  //Declare vars here
  const float GRAVITY = 200f;
  const int SPEED = 100;

  Vector2 velocity;

  public override void _Ready(){
	GD.Print("Getting the Ready Ready...");
  }

  public void getInput(){
	if(Input.IsActionJustPressed("move_right")){
	  velocity.x = SPEED;
	}
	if(Input.IsActionJustPressed("move_left")){
	  velocity.x = -SPEED;
	}
  }

  public override void _PhysicsProcess(float delta)
  {
	//This was brought in default
	// base._PhysicsProcess(delta);

	//Detecting the ground
	velocity.y += delta * GRAVITY;
	getInput();
	MoveAndSlide(velocity, new Vector2(0, -1));
  }
}
