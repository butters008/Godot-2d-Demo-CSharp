using Godot;
using System;

public class BobV2 : KinematicBody2D
{
  //Declare vars here
  const float GRAVITY = 200f;
  const int SPEED = 100;
  Vector2 velocity;
	AnimationPlayer animationPlayer;

  public override void _Ready(){
		GD.Print("Getting the Ready Ready...");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		//Testing
  }

  public void getInput(){
		if(Input.IsActionJustPressed("move_right")){
			velocity.x = SPEED;
			animationPlayer.Play("Walk");
			GetNode<Sprite>("Sprite").FlipH = false;
		}
		else if(Input.IsActionJustPressed("move_left")){
			velocity.x = -SPEED;
			animationPlayer.Play("Walk");
			GetNode<Sprite>("Sprite").FlipH = true;
		}
		else{
			animationPlayer.Play("Idle");
			velocity.x = Mathf.Lerp(velocity.x, 0, 0.25f);
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
