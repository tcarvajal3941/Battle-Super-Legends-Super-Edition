using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {
	public int  inputDirection;
	public int  inputButton;

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	bool  facingRight; //pull from other scripts
	float jumpHeight;
	int   airOptions;
	float gravity;
	float dashMultiplier;

	float lspeed;
	float rspeed;
	bool  grounded;
	int   jumpDirection = 0;
	float setJumpHeight;
	int   setAirOptions;

	// Use this for initialization
	void Start () {
		facingRight = true;
		inputDirection = 5;

		fwalk         = .05f;
		bwalk         = .035f;
		setJumpHeight = .2f;
		setAirOptions = 2;
		gravity       = .01f;

		bwalk       = bwalk*-1;
		facingRight = true;
		grounded    = true;
	}
	
	// Update is called once per frame
	void Update () {
		getInput();
		Debug.Log("Input Direction: " + inputDirection);
	}

	public void getInput()
	{
		inputDirection = 5;
		//walk to the left
		if (Input.GetKey(KeybindingsScript.Kb.left))
		{
			inputDirection = 4;
			Debug.Log(inputDirection);
		}
		//walk to the right
		if (Input.GetKey(KeybindingsScript.Kb.right))
		{
			inputDirection = 6;
		}

		//grounded jump
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump))
		{
			inputDirection = 8;
		}
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.left))
		{
			inputDirection = 7;
		}
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.right))
		{
			inputDirection = 9;
		}
		
		//crouch
		if (Input.GetKey(KeybindingsScript.Kb.crouch))
		{
			inputDirection = 2;
		}
		if (Input.GetKey(KeybindingsScript.Kb.crouch) && Input.GetKey(KeybindingsScript.Kb.left))
		{
			inputDirection = 1;
		}
		if (Input.GetKey(KeybindingsScript.Kb.crouch) && Input.GetKey(KeybindingsScript.Kb.right))
		{
			inputDirection = 3;
		}
		Move(inputDirection);
	}

	// Update is called once per frame
	public void Move (int inputDirection) {
		if (facingRight == true)
		{
			lspeed = bwalk;
			rspeed = fwalk * dashMultiplier;
		}
		
		if (facingRight == false)
		{
			lspeed = fwalk * dashMultiplier;
			rspeed = bwalk;
		}

		if (inputDirection == 4)//walk Backwards
		{
			for (int i = 0; i > 8; i++)
			{
				if (inputDirection == 5)
				{
					for (int j = 0; j > 8; j++)
					{
						if (inputDirection == 4)
						{
							transform.position = getDash(grounded, facingRight, fwalk, bwalk, false);
						}
					}
				}
			}
			if (grounded == true)
			{
				transform.Translate(lspeed, 0, 0);
			}
			else if (grounded == false && jumpDirection == 8)
			{
            	transform.Translate(lspeed*.5f, 0, 0);
			}
		}
		if (inputDirection == 6)//walk Forwards
		{
			for (int i = 0; i > 8; i++)
			{
				if (inputDirection == 5)
				{
					for (int j = 0; j > 8; j++)
					{
						if (inputDirection == 6)
						{
							transform.position = getDash(grounded, facingRight, fwalk, bwalk, true);
						}
					}
				}
			}
			if (grounded == true)
			{
				transform.Translate(rspeed, 0, 0);
			}
			else if (grounded == false && jumpDirection == 8)
			{
				transform.Translate(rspeed*.5f, 0, 0);
			}
		}
		if (grounded == true || grounded == false && airOptions > 0)
		{
			if (inputDirection == 7)//jump Backwards
			{
				jumpDirection = 7;
				grounded = false;
				jumpHeight = setJumpHeight;
				transform.position = getGravity(jumpDirection, grounded);
			}
			else if (inputDirection == 8)//Neutral Jump, steerable
			{
				jumpDirection = 8;
				grounded = false;
				jumpHeight = setJumpHeight;
				transform.position = getGravity(jumpDirection, grounded);
			}
			else if (inputDirection == 9)//jump Forwards
			{
				jumpDirection = 9;
				grounded = false;
				jumpHeight = setJumpHeight;
				transform.position = getGravity(jumpDirection, grounded);
			}
			airOptions--;
		}

		//activates gravity if airborn
		if (grounded == false)
		{
			transform.position = getGravity(jumpDirection, grounded);
		}

		//crouching
		if (inputDirection == 1 || 
			inputDirection == 2 || inputDirection == 3)
		{
			//crouch
			
		}

		//sets ground limit and resets air options
		if (transform.position.y <= 0)
		{
			transform.position = new Vector2(transform.position.x, 0);
			grounded = true;
			jumpHeight = setJumpHeight;
			airOptions = setAirOptions;
			jumpDirection = 0;
		}
	}

	//calculates gravity
	private Vector2 getGravity(int jumpDirection, bool grounded)
	{
		if (grounded == false)
		{
			gravity = .01f;
			if (jumpDirection == 9)
			{
				transform.Translate(rspeed * .85f, 0, 0);
			}
			else if (jumpDirection == 7)
			{
				transform.Translate(lspeed * .85f, 0, 0);
			}
			transform.Translate(0, jumpHeight, 0);
			jumpHeight -= gravity;
		}
		return transform.position;
	}

	private Vector2 getDash(bool grounded, bool facingRight, float fwalk, float bwalk, bool fdash)
	{
		float move = 0;
		if (fdash)
		{
			if (facingRight)
			{
				if (grounded)
				{
					move = fwalk * 2;
				}
				else if (!grounded)
				{
					move = fwalk * 2;
				}
			}
			if (!facingRight)
			{
				if (grounded)
				{
					move = fwalk * 2;
				}
				else if (!grounded)
				{
					move = fwalk * 2;
				}
			}
		}
		if (!fdash)
		{
			if (facingRight)
			{
				if (grounded)
				{
					move = bwalk * 2;
				}
				else if (!grounded)
				{
					move = bwalk * 2;
				}
			}
			if (!facingRight)
			{
				if (grounded)
				{
					move = bwalk * 2;
				}
				else if (!grounded)
				{
					move = bwalk * 2;
				}
			}
		}
		transform.Translate(move, transform.position.y, 0);
		return transform.position;
	}
}