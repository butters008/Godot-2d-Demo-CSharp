using Godot;
using System;
using System.Diagnostics;

public partial class BobV2 : CharacterBody2D
{
	//Declare vars here
	const float GRAVITY = 100f;
	const int SPEED = 75;
	const int JUMP = 50;
	Vector2 velocity;
	AnimatedSprite2D animatedSprite;

	//Console.WriteLine("Hello");


	public override void _Ready()
	{
		Debug.WriteLine("Hello");
		GD.Print("Getting the Ready Ready...");
		//		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

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
		if (IsOnFloor())
		{
			float direction = Input.GetAxis("move_left", "move_right");
			velocity.X = direction * SPEED;
		}





		//Detecting the ground
		MoveAndSlide();


		Velocity = velocity;

		//MoveAndSlide(velocity, (new Vector2(0, -1)));
	}
}
