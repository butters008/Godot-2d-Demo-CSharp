using Godot;
using System;

public class Bob : KinematicBody2D
{
	//Redoing this all and going off of Godot docs

	//Declaring vars
	const float GRAVITY = 200.0f;
	const int SPEED = 200;
	const int JUMP = -100;
	Vector2 velocity;
	AnimationPlayer animePlayer;

	//Need the _Ready function to make the player animation = can't declare and add like Java
	public override void _Ready(){
		animePlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	//Still going to do input method if I can 
	public void getInput(){
		if(Input.IsActionPressed("move_right") && IsOnFloor()){
			velocity.x = SPEED;
			GetNode<Sprite>("Sprite").FlipH = false;
			animePlayer.Play("Walk");
		}
		else if(Input.IsActionPressed("move_left" ) && IsOnFloor()){
			velocity.x = -SPEED;
			GetNode<Sprite>("Sprite").FlipH = true;
			animePlayer.Play("Walk");

		}
		else if(Input.IsActionJustPressed("jump") && IsOnFloor()){
			velocity.y = JUMP;
		}
		else{
			animePlayer.Play("Idle1");
			velocity.x = Mathf.Lerp(velocity.x, 0, 0.25f);
		}

		if(Input.IsActionJustPressed("attack")){
			GD.Print("Attacking!");
		}
	}


	public override void _PhysicsProcess(float delta){

		//Detecting if there is ground
		velocity.y += delta * GRAVITY;

		getInput();
		MoveAndSlide(velocity, new Vector2(0, -1));

	}


	
}
