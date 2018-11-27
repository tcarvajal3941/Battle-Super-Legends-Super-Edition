using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {

	public float groundLevel = -0.8f;

	public int  inputDirection;
	public int  inputButton;

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	bool  facingRight; //pull from other scripts
	float jumpHeight;
	int   airOptions;
	float gravity;
	float dashSpeed;

	float walkspeed;
	float rspeed;
	bool  grounded;
	int   jumpDirection = 0;
	float setJumpHeight;
	int   setAirOptions;

	// Use this for initialization
	void Start () {
		facingRight = true;
		walkspeed = .75f;
	}
	
	// Update is called once per frame
	void Update () {
		//move left
		if (Input.GetKey(KeybindingsScript.Kb.left))
		{
			if (grounded == true)
			{
				transform.Translate(walkspeed*-1, 0, 0);
			}
			else if (grounded == false && jumpDirection == 8)
			{
            	transform.Translate(walkspeed*-.5f, 0, 0);
			}
			Debug.Log("Moving Left");
		}

		//move right
		if (Input.GetKey(KeybindingsScript.Kb.right))
		{
			if (grounded == true)
			{
				transform.Translate(walkspeed, 0, 0);
			}
			else if (grounded == false && jumpDirection == 8)
			{
            	transform.Translate(walkspeed*.5f, 0, 0);
			}
			Debug.Log("Moving Right");
		}
		
		//jump
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump))
		{
			jumpDirection = 8;
			grounded = false;
			jumpHeight = setJumpHeight;
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.left))
		{
			jumpDirection = 7;
			grounded = false;
			jumpHeight = setJumpHeight;
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.right))
		{
			jumpDirection = 9;
			grounded = false;
			jumpHeight = setJumpHeight;
			transform.position = getGravity(jumpDirection, grounded);
		}

		//activate gravity if airborn
		if (!grounded)
		{
			transform.position = getGravity(jumpDirection, grounded);
		} else {
			jumpHeight = setJumpHeight;
			airOptions = setAirOptions;
			jumpDirection = 0;
		}
	}

	//calculate gravity
	private Vector2 getGravity(int jumpDirection, bool grounded)
	{
		if (!grounded)
		{
			gravity = .01f;
			if (jumpDirection == 9)
			{
				transform.Translate(walkspeed*.85f, 0, 0);
			}
			else if (jumpDirection == 7)
			{
				transform.Translate(walkspeed*-.85f, 0, 0);
			}
			transform.Translate(0, jumpHeight, 0);
			jumpHeight -= gravity;
		}
		return transform.position;
	}
}