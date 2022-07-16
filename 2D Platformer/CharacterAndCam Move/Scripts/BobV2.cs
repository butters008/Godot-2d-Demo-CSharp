using Godot;
using System;

public class BobV2 : KinematicBody2D
{
  //Declare vars here
  const float GRAVITY = 100f;
  const int SPEED = 50;
  Vector2 velocity;
	// AnimationPlayer animationPlayer;
	AnimatedSprite animatedSprite;


  public override void _Ready(){
		GD.Print("Getting the Ready Ready...");
		// animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
  }

  public void getInput(){
		if(Input.IsActionPressed("move_right")){
			velocity.x = SPEED;
			animatedSprite.Play("Walk");
			GetNode<AnimatedSprite>("AnimatedSprite").FlipH = false;
			// animationPlayer.Play("Walk");
			// GetNode<Sprite>("Sprite").FlipH = false;
		}
		else if(Input.IsActionPressed("move_left")){
			velocity.x = -SPEED;
			animatedSprite.Play("Walk");
			GetNode<AnimatedSprite>("AnimatedSprite").FlipH = true;
			// animationPlayer.Play("Walk");
			// GetNode<Sprite>("Sprite").FlipH = true;
		}
		else{
			animatedSprite.Play("Idle");
			// animationPlayer.Play("Idle");
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
