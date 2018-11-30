using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {
	public static CombinedMove Cm;

	Animator   animator;
	int        action;
	public int moveDirection;

	private bool pressedOnce;
    private float time;
    private float timerLength;

	bool  steerable;
	bool  setSteerable;
	float jumpHeight;
	int   airOptions;
	float gravity;
	float dashSpeed;
	float walkspeed;
	bool  grounded;
	int   jumpDirection;
	float setJumpHeight;
	int   setAirOptions;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();

		setSteerable = false;
		setJumpHeight = .3f;
		setAirOptions = 1;
		jumpHeight = setJumpHeight;
		airOptions = setAirOptions;
		walkspeed = .12f;
		grounded = true;
		gravity = .02f;
		jumpDirection = 0;

		pressedOnce = false;
        time = 0;
        timerLength = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool("grounded", grounded);
		action = 0;
		animator.SetInteger("action", action);
		moveDirection = 0;
		animator.SetInteger("moveDirection", moveDirection);

		//light attack
		if (Input.GetKeyDown(KeybindingsScript.Kb.lightAttack))
		{
			action = 1;
			animator.SetInteger("action", action);
			Debug.Log("Light Attack Pressed");
		}
		//heavy attack
		if (Input.GetKeyDown(KeybindingsScript.Kb.mediumAttack))
		{
			action = 2;
			animator.SetInteger("action", action);
			Debug.Log("Medium Attack Pressed");
		}

		//move left
		if (Input.GetKey(KeybindingsScript.Kb.left))
		{
			
			int moveDirection = -1;
			if (grounded)
			{
				animator.SetInteger("moveDirection", moveDirection);
				transform.Translate(walkspeed*-1, 0, 0);
			}
			else if (!grounded)
			{
				animator.SetInteger("moveDirection", moveDirection);
				transform.Translate(walkspeed*-.85f, 0, 0);
			}
			Debug.Log("Moving Left");
		}

		//move right
		if (Input.GetKey(KeybindingsScript.Kb.right))
		{
			int moveDirection = 1;
			if (grounded)
			{
				animator.SetInteger("moveDirection", moveDirection);
				transform.Translate(walkspeed, 0, 0);
			}
			else if (!grounded)
			{
				animator.SetInteger("moveDirection", moveDirection);
				transform.Translate(walkspeed*.85f, 0, 0);
			}
			Debug.Log("Moving Right");
		}
		
		//jump
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump))
		{
			if (grounded)			
				transform.position = getJump();
			else if (airOptions > 0)
			{
				airOptions--;
				transform.position = getJump();
			}
		}

		//activate gravity if airborn
		if (!grounded && transform.position.y > -.8f)
		{
			transform.position = getGravity(jumpDirection, grounded);
		}
		if (transform.position.y <= -.8f) {
			grounded = true;
			animator.SetBool("grounded", grounded);
			transform.position = new Vector2(transform.position.x, -.8f);
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
			transform.Translate(0, jumpHeight, 0);
			jumpHeight -= gravity;
		}
		return transform.position;
	}

	public Vector2 getJump()
	{
		animator.SetInteger("moveDirection", 2);
		jumpHeight = setJumpHeight;
		grounded = false;
		transform.position = getGravity(jumpDirection, grounded);

		Debug.Log("Jumping");
		return transform.position;
	}
}