using Godot;
using System;
using System.Diagnostics;

/*
This is going to be the characterbody main class for the player in the 2D platformer demo
I am going to try my hardest, to comment what I am doing for my own self by for anyone who wants
to look at this repo for themselves
*/

public partial class BobV2 : CharacterBody2D
{
	//Declare vars here
	const float GRAVITY = 100f;
	const int SPEED = 75;
	const int JUMP = 50;
	Vector2 velocity;
	AnimatedSprite2D animatedSprite;

	public override void _PhysicsProcess(double delta)
	{
		//declare vars and objects
		Vector2 velocity = Velocity;

		//Determine gravity
		velocity.Y += GRAVITY * (float)delta;

		//Move and Jump
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			Debug.WriteLine("Inside Jump");
			velocity.Y = -JUMP;
		}
		if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
		{
			float direction = Input.GetAxis("move_left", "move_right");
			Debug.WriteLine(direction);
			velocity.X = direction * SPEED;
		}
		else
		{
			velocity.X = 0;
		}
		//This has delta built inside of it - this is prebuilt move/collision method that is used
		MoveAndSlide();
		//This is used for movement as well.
		Velocity = velocity;

	}
}
