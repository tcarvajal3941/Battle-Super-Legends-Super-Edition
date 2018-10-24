using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	bool facingRight; //pull from other scripts
	float jumpHeight;
	int doubleJumps;
	float gravity;

	float lspeed;
	float rspeed;
	bool grounded;
	int jumpDirection = 0;
	int setJumpHeight;
	int setDoubleJumps;

	// Use this for initialization
	void Start () {
		fwalk = 3;
		bwalk = 2;
		setJumpHeight = 15;
		setDoubleJumps = 1;

		gravity = .75f;
		bwalk = bwalk*-1;
		facingRight = true;
		grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (facingRight == true)
		{
			lspeed = bwalk;
			rspeed = fwalk;
		}
		
		if (facingRight == false)
		{
			lspeed = fwalk;
			rspeed = bwalk;
		}

		if (InputReaderMk4.GM1.inputDirection == 4)//walk Backwards
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
		if (InputReaderMk4.GM1.inputDirection == 6)//walk Forwards
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

		if (InputReaderMk4.GM1.inputDirection == 7)//jump Backwards
		{
			jumpDirection = 7;
			grounded = false;
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (InputReaderMk4.GM1.inputDirection == 8)//Neutral Jump, steerable
		{
			jumpDirection = 8;
			grounded = false;
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (InputReaderMk4.GM1.inputDirection == 9)//jump Forwards
		{
			jumpDirection = 9;
			grounded = false;
			transform.position = getGravity(jumpDirection, grounded);
		}

		//activates gravity if airborn
		if (grounded == false)
		{
			transform.position = getGravity(jumpDirection, grounded);
		}

		//crouching
		if (InputReaderMk4.GM1.inputDirection == 1 || 
			InputReaderMk4.GM1.inputDirection == 2 || InputReaderMk4.GM1.inputDirection == 3)
		{
			//crouch
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

	//calculates gravity
	private Vector2 getGravity(int jumpDirection, bool grounded)
	{
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
		return transform.position;
	}
}
