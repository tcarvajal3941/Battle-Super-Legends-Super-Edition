using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderMk2 : MonoBehaviour {

	//KeybindingsScript callKeybindingScript = new KeybindingsScript();

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	float jumpHeight; //pull from other scripts
	float setJumpHeight = 15; //pull from other scripts
	float lspeed;
	float rspeed;
	float gravity;
	int inputDirection;
	int jumpDirection;
	int setDoubleJumps = 1; //pull from other scripts
	int doubleJumps;
	bool resetGravity;
	bool grounded = true; //pull from other scripts
	bool facingRight = false; //pull from other scripts

	// Use this for initialization
	void Start () {
		fwalk = 3;
		bwalk = 2;
		jumpHeight = setJumpHeight;
		gravity = .75f;
		jumpDirection = 0;
		doubleJumps = setDoubleJumps;
		resetGravity = false;
		transform.position = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		//start collecting inputs and movement directions
		if (facingRight == false)
		{
			//walk to the left
			if (Input.GetKey(KeyCode.LeftArrow))
        	{
				inputDirection = 6;
        	}
			//walk to the right
        	if (Input.GetKey(KeyCode.RightArrow))
        	{
				inputDirection = 4;
        	}

			//grounded jump
			if (Input.GetKeyDown(KeyCode.UpArrow))
        	{
				inputDirection = 8;
			}
			if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				inputDirection = 9;
			}
			if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow))
			{
				inputDirection = 7;
			}
			
			//crouch
        	if (Input.GetKey(KeyCode.DownArrow))
        	{
				inputDirection = 2;
			}
			if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
			{
				inputDirection = 3;
			}
			if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
			{
				inputDirection = 1;
			}
		}
		if (facingRight == true)
		{
			//walk to the left
			if (Input.GetKey(KeyCode.LeftArrow))
        	{
				inputDirection = 4;
        	}
			//walk to the right
        	if (Input.GetKey(KeyCode.RightArrow))
        	{
				inputDirection = 6;
        	}

			//grounded jump
			if (Input.GetKeyDown(KeyCode.UpArrow))
        	{
				inputDirection = 8;
			}
			if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				inputDirection = 7;
			}
			if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow))
			{
				inputDirection = 9;
			}
			
			//crouch
        	if (Input.GetKey(KeyCode.DownArrow))
        	{
				inputDirection = 2;
			}
			if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
			{
				inputDirection = 1;
			}
			if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
			{
				inputDirection = 3;
			}
		}

		if (facingRight == true)
		{
			lspeed = bwalk;
			rspeed = fwalk;
			string fdir = "right";
			string bdir = "left";
		}
		if (facingRight == false)
		{
			lspeed = fwalk;
			rspeed = bwalk;
			string fdir = "left";
			string bdir = "right";
		}

		//left/right movement
		if (inputDirection == 4)
		{
			if (grounded == true)
			{
            	transform.position += Vector3.left * lspeed * Time.deltaTime;
			}
			else if (grounded == false && jumpDirection == 8)
			{
            	transform.position += Vector3.left * (lspeed * .5f) * Time.deltaTime;
			}
		}
		if (inputDirection == 6)
		{
			if (grounded == true)
			{
            	transform.position += Vector3.right * rspeed * Time.deltaTime;
			}
			if (grounded == false && jumpDirection == 8)
			{
            	transform.position += Vector3.right * (rspeed * .5f) * Time.deltaTime;
			}
		}

		//jumping
		if (inputDirection == 7)
		{
			jumpDirection = 7;
			transform.position += Vector3.left * (lspeed * .85f) * Time.deltaTime;

			transform.position += Vector3.up * jumpHeight * Time.deltaTime;
			grounded = false;
		}
		if (inputDirection == 8)
		{
			jumpDirection = 8;

			transform.position += Vector3.up * jumpHeight * Time.deltaTime;
			grounded = false;
		}
		if (inputDirection == 9)
		{
			jumpDirection = 9;
			transform.position += Vector3.right * (rspeed * .85f) * Time.deltaTime;

			transform.position += Vector3.up * jumpHeight * Time.deltaTime;
			grounded = false;
		}

		//crouching
		if (inputDirection == 1 || inputDirection == 2 || inputDirection == 3)
		{
			//crouch
		}

		//return to idle
		if (!Input.anyKeyDown)
		{
			inputDirection = 5;
		}
		//end of input and movement


		//part of jump, calculates gravity and horizontal momentum, DO NOT DELETE
		if (grounded == false)
		{
			if (jumpDirection == 9)
			{
				transform.position += Vector3.right * (rspeed * .85f) * Time.deltaTime;
			}
			if (jumpDirection == 7)
			{
				transform.position += Vector3.left * (lspeed * .85f) * Time.deltaTime;
			}

			transform.position += Vector3.up * jumpHeight * Time.deltaTime;
			jumpHeight -= gravity;
		}

		//sets ground limit and resets air options
		if (transform.position.y <= 0)
		{
			transform.position = new Vector2(transform.position.x, 0);
			grounded = true;
			jumpHeight = setJumpHeight;
			doubleJumps = setDoubleJumps;
			jumpDirection = 0;
		}
	}
}
