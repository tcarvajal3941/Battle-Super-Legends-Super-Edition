using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {

	bool  steerable;
	bool  setSteerable;
	float jumpHeight;
	int   airOptions;
	float gravity;
	float dashSpeed;
	float walkspeed = .75f;
	bool  grounded;
	int   jumpDirection = 0;
	float setJumpHeight;
	int   setAirOptions;

	bool  lightAttack;

	// Use this for initialization
	void Start () 
	{
		setSteerable = false;
		setJumpHeight = 5;
		setAirOptions = 1;
		jumpHeight = setJumpHeight;
		airOptions = setAirOptions;
		walkspeed = .75f;
		dashSpeed = walkspeed * 2;
		grounded = true;
		gravity = .01f;
		jumpDirection = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeybindingsScript.Kb.lightAttack))
		{
			lightAttack = true;
		}
		//move left
		if (Input.GetKey(KeybindingsScript.Kb.left))
		{
			if (grounded == true)
			{
				transform.Translate(walkspeed*-1, 0, 0);
			}
			else if (grounded == false && steerable)
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
			else if (grounded == false && steerable)
			{
            	transform.Translate(walkspeed*.5f, 0, 0);
			}
			Debug.Log("Moving Right");
		}
		
		//jump
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump))
		{
			jumpDirection = 8;
			steerable = true;
			grounded = false;
			jumpHeight = setJumpHeight;
			transform.position = getGravity(jumpDirection, grounded);
			jumpDirection = 0;
		}
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.left))
		{
			jumpDirection = 7;
			steerable = setSteerable;
			grounded = false;
			jumpHeight = setJumpHeight;
			transform.position = getGravity(jumpDirection, grounded);
			jumpDirection = 0;
		}
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.right))
		{
			jumpDirection = 9;
			steerable = setSteerable;
			grounded = false;
			jumpHeight = setJumpHeight;
			transform.position = getGravity(jumpDirection, grounded);
			jumpDirection = 0;
		}

		//activate gravity if airborn
		if (!grounded)
		{
			transform.position = getGravity(jumpDirection, grounded);
		} else {
			transform.position = new Vector2(transform.position.x, -.8f);
			grounded = true;
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