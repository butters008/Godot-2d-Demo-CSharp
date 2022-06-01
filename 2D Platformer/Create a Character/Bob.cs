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


	//Still going to do input method if I can 
	public void getInput(){
		if(Input.IsActionPressed("move_right")){
			velocity.x = SPEED;
		}
		if(Input.IsActionPressed("move_left" )){
			velocity.x = -SPEED;
		}
		if(Input.IsActionJustPressed("jump") && IsOnFloor()){
			velocity.y = JUMP;
		}
		else{
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
