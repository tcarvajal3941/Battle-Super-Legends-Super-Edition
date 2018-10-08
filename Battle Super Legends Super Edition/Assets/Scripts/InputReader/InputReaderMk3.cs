using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderMk3 : MonoBehaviour {

	KeybindingsScript callKeybindingScript = new KeybindingsScript();

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
	bool facingRight = true; //pull from other scripts

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
			lspeed = bwalk*-1;
			rspeed = fwalk;
		}
		
		if (facingRight == false)
		{
			lspeed = fwalk;
			rspeed = bwalk*-1;
		}

		if (inputDirection == 4)
		{
			if (grounded == true)
			{
				Vector2 tempVec = transform.position;
				tempVec.x += transform.position.x * lspeed * Time.deltaTime;
            	transform.position = tempVec;
			}
			else if (grounded == false && jumpDirection == 8)
			{
            	Vector2 tempVec = transform.position;
				tempVec.x += transform.position.x * (lspeed * .5f) * Time.deltaTime;
            	transform.position = tempVec;
			}
		}
			if (inputDirection == 6)
			{
				if (grounded == true)
				{
            		Vector2 tempVec = transform.position;
					tempVec.x += transform.position.x * rspeed * Time.deltaTime;
            		transform.position = tempVec;
				}
				if (grounded == false && jumpDirection == 8)
				{
            		Vector2 tempVec = transform.position;
					tempVec.x += transform.position.x * (rspeed * .5f) * Time.deltaTime;
            		transform.position = tempVec;
				}
			}

			//jumping
			if (inputDirection == 7)
			{
				jumpDirection = 7;

				Vector2 tempVec = transform.position;
				tempVec.x += transform.position.x * (lspeed * .85f) * Time.deltaTime;
				tempVec.y += transform.position.y * jumpHeight * Time.deltaTime;
            	transform.position = tempVec;

				grounded = false;
			}
			if (inputDirection == 8)
			{
				jumpDirection = 8;

				Vector2 tempVec = transform.position;
				tempVec.y += transform.position.y * jumpHeight * Time.deltaTime;
            	transform.position = tempVec;

				grounded = false;
			}
			if (inputDirection == 9)
			{
				jumpDirection = 9;
				
				Vector2 tempVec = transform.position;
				tempVec.x += transform.position.x * (rspeed * .85f) * Time.deltaTime;
				tempVec.y += transform.position.y * jumpHeight * Time.deltaTime;
            	transform.position = tempVec;

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
					Vector2 tempVecII = transform.position;
					tempVecII.x += transform.position.x * (rspeed * .85f) * Time.deltaTime;
            		transform.position = tempVecII;
				}
				if (jumpDirection == 7)
				{
					Vector2 tempVecII = transform.position;
					tempVecII.x += transform.position.x * (lspeed * .85f) * Time.deltaTime;
            		transform.position = tempVecII;
				}

			Vector2 tempVec = transform.position;
			tempVec.y += transform.position.y * jumpHeight * Time.deltaTime;
            transform.position = tempVec;
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
