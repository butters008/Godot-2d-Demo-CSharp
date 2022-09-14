using Godot;
using System;

public class BobV2 : KinematicBody2D
{
  //Declare vars here
  const float GRAVITY = 50f;
  const int SPEED = 50;
	const int JUMP = 100;
  Vector2 velocity;
	AnimatedSprite animatedSprite;


  public override void _Ready(){
		GD.Print("Getting the Ready Ready...");
		animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
  }

  public void getInput(){
		if(Input.IsActionPressed("move_right")){
			velocity.x = SPEED;
			animatedSprite.Play("Walk");
			GetNode<AnimatedSprite>("AnimatedSprite").FlipH = false;
		}
		else if(Input.IsActionPressed("move_left")){
			velocity.x = -SPEED;
			animatedSprite.Play("Walk");
			GetNode<AnimatedSprite>("AnimatedSprite").FlipH = true;
		}
		else if(Input.IsActionPressed("jump")){
			velocity.y = JUMP;
		}
		else{
			animatedSprite.Play("Idle");
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
