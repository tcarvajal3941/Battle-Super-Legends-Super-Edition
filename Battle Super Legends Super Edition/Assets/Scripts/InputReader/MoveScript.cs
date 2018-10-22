using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	bool facingRight; //pull from other scripts
	float jumpHeight;
	float gravity;
	int doubleJumps;

	float lspeed;
	float rspeed;
	bool grounded;
	int jumpDirection = 0;
	int setJumpHeight;
	int setDoubleJumps;

	int playerInputDirection;
	int playerInputButton;

	// Use this for initialization
	void Start () {
	//	InputReaderMk4 InputReader = gameObject.GetComponent<InputReaderMk4>();
	//	CharacterData charData = gameObject.GetComponent<CharacterData>();

		setJumpHeight = gameObject.GetComponent<CharacterData>().jumpHeight;
		doubleJumps = setDoubleJumps = gameObject.GetComponent<CharacterData>().doubleJumps;
		gravity = gameObject.GetComponent<CharacterData>().gravity;
		fwalk = gameObject.GetComponent<CharacterData>().fwalk;
		bwalk = gameObject.GetComponent<CharacterData>().bwalk;

		bwalk = bwalk*-1;
		facingRight = true;
		grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		playerInputDirection = gameObject.GetComponent<InputReaderMk4>().inputDirection;
		playerInputButton = gameObject.GetComponent<InputReaderMk4>().inputButton;
		
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

		if (playerInputDirection == 4)//walk Backwards
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
		if (playerInputDirection == 6)//walk Forwards
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

		if (playerInputDirection == 7)//jump Backwards
		{
			jumpDirection = 7;
			grounded = false;
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (playerInputDirection == 8)//Neutral Jump, steerable
		{
			jumpDirection = 8;
			grounded = false;
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (playerInputDirection == 9)//jump Forwards
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
		if (playerInputDirection == 1 || playerInputDirection == 2 || playerInputDirection == 3)
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
