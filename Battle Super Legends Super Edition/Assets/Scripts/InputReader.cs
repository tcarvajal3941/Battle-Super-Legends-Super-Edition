﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour {

	KeybindingsScript callKeybindingScript = new KeybindingsScript();

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	float jumpHeight; //pull from other scripts
	float setJumpHeight = 15; //pull from other scripts
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
		if (facingRight == true)
		{
			//walk to the left
			if (Input.GetKey(callKeybindingScript.left))
        	{
				inputDirection = 4;
				if (grounded == true)
				{
            		transform.position += Vector3.left * bwalk * Time.deltaTime;
				}
				else if (grounded == false && jumpDirection == 8)
				{
            		transform.position += Vector3.left * (bwalk * .5f) * Time.deltaTime;
				}
        	}

			//walk to the right
        	if (Input.GetKey(callKeybindingScript.right))
        	{
				inputDirection = 6;
				if (grounded == true)
				{
            		transform.position += Vector3.right * fwalk * Time.deltaTime;
				}
				if (grounded == false && jumpDirection == 8)
				{
            		transform.position += Vector3.right * (fwalk * .5f) * Time.deltaTime;
				}
        	}

			//grounded jump
			if (Input.GetKeyDown(callKeybindingScript.jump) && grounded == true)
        	{
				inputDirection = 8;
				jumpDirection = 8;
				if (Input.GetKey(callKeybindingScript.jump) && Input.GetKeyDown(callKeybindingScript.left))
				{
					transform.position += Vector3.left * (bwalk * .75f) * Time.deltaTime;
					inputDirection = 7;
					jumpDirection = 7;
				}
				if (Input.GetKey(callKeybindingScript.jump) && Input.GetKeyDown(callKeybindingScript.right))
				{
					transform.position += Vector3.right * (fwalk * .75f) * Time.deltaTime;
					inputDirection = 9;
					jumpDirection = 9;
				}
				transform.position += Vector3.up * jumpHeight * Time.deltaTime;
				grounded = false;
			}

			//double jump (broken as hell)
			if (Input.GetKeyDown(callKeybindingScript.jump) && grounded == false && doubleJumps > 0)
        	{
				resetGravity = true;
				inputDirection = 8;
				jumpDirection = 8;
				if (Input.GetKey(callKeybindingScript.jump) && Input.GetKeyDown(callKeybindingScript.left))
				{
					transform.position += Vector3.left * (bwalk * .75f) * Time.deltaTime;
					inputDirection = 7;
					jumpDirection = 7;
				}
				if (Input.GetKey(callKeybindingScript.jump) && Input.GetKeyDown(callKeybindingScript.right))
				{
					transform.position += Vector3.right * (fwalk * .75f) * Time.deltaTime;
					inputDirection = 9;
					jumpDirection = 9;
				}
				transform.position += Vector3.up * jumpHeight * Time.deltaTime;
				grounded = false;
				doubleJumps--;
			}

			//crouch
        	if (Input.GetKey(callKeybindingScript.crouch))
        	{
				inputDirection = 2;
				if (Input.GetKey(callKeybindingScript.crouch) && Input.GetKey(callKeybindingScript.left))
				{
					inputDirection = 1;
				}
				if (Input.GetKey(callKeybindingScript.crouch) && Input.GetKey(callKeybindingScript.right))
				{
					inputDirection = 3;
				}
        	}
		}

		//return to idle
		if (Input.GetKeyDown(KeyCode.None))
		{
			inputDirection = 5;
		}
		//end of input and movement


		//part of jump, calculates gravity and horizontal momentum, DO NOT DELETE
		if (grounded == false)
		{
			//part of double jump, resets fall speed to jump height
			if (resetGravity == true)
			{
				jumpHeight = setJumpHeight;
				resetGravity = false;
			}

			if (jumpDirection == 9)
			{
				transform.position += Vector3.right * (fwalk * .75f) * Time.deltaTime;
			}
			if (jumpDirection == 7)
			{
				transform.position += Vector3.left * (bwalk * .75f) * Time.deltaTime;
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