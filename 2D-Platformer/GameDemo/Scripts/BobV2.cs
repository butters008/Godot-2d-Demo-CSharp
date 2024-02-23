using Godot;
using System;
using System.Diagnostics;

public partial class BobV2 : CharacterBody2D
{
	//Declare vars here
	const float GRAVITY = 50f;
	const int SPEED = 75;
	const int JUMP = 100;
	Vector2 velocity;
	AnimatedSprite2D animatedSprite;

	//Console.WriteLine("Hello");


	public override void _Ready()
	{
		Debug.WriteLine("Hello");
		GD.Print("Getting the Ready Ready...");
		//		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	//
	public void getInput()
	{
		if (Input.IsActionPressed("move_right"))
		{
			velocity.X = SPEED;
			animatedSprite.Play("Walk");
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
		}
		else if (Input.IsActionPressed("move_left"))
		{
			velocity.X = -SPEED;
			animatedSprite.Play("Walk");
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		}
		else if (Input.IsActionPressed("jump"))
		{
			velocity.Y = JUMP;
		}
		else
		{
			animatedSprite.Play("Idle");
			velocity.X = Mathf.Lerp(velocity.X, 0, 0.25f);
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		//This was brought in default
		// base._PhysicsProcess(delta);

		//Detecting the ground
		velocity.Y += delta * GRAVITY;
		getInput();

		//MoveAndSlide(velocity, (new Vector2(0, -1)));
	}
}
