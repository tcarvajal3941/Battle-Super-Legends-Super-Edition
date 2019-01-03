using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {

	public static CombinedMove Cm;
	private int   dashSpeedInputDuration = 40;

	//used by animator
	Animator           animator;
	SpriteRenderer     spriteRenderer;
	public static bool facingRight;
	int                action;
	int                moveDirection;
	bool               grounded;

	//used by movement
	int   setAirOptions;
	int   buttonHeld;
	int   airOptions;
	float jumpHeight;
	float gravity;
	float dashSpeed;
	float walkspeed;
	float setJumpHeight;
	float speedMultiplier;

	Vector2 prevYPos;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		setJumpHeight = .2f;  //changeable
		setAirOptions = 1;    //changeable
		walkspeed     = .06f; //changeable
		dashSpeed     = 1.75f; //changeable
		gravity       = .015f; //changeable
		jumpHeight    = setJumpHeight;
		airOptions    = setAirOptions;
		grounded      = true;
		facingRight   = true;
	}
	
	// Update is called once per frame
	void Update () {
		//update animator
		animator.SetInteger("action", action);
		animator.SetInteger("moveDirection", moveDirection);
		animator.SetBool("grounded", grounded);
		animator.SetBool("facingRight", facingRight);
		if (facingRight){spriteRenderer.flipX = false;}
		else if (!facingRight){spriteRenderer.flipX = true;}
		//collect vertical speed
		animator.SetFloat("vspeed", 
			(transform.position.y - prevYPos.y) / Time.deltaTime);
		prevYPos = transform.position;

		//light attack
		if (Input.GetKeyDown(KeybindingsScript.Kb.lightAttack))
		{
			action = 1;
			Debug.Log("Light Attack Pressed");
		}
		//heavy attack
		if (Input.GetKeyDown(KeybindingsScript.Kb.mediumAttack))
		{
			action = 2;
			Debug.Log("Medium Attack Pressed");
		}

		//move left
		if (Input.GetKey(KeybindingsScript.Kb.left))
		{
			moveDirection = -1;
			if (buttonHeld >= dashSpeedInputDuration)
			{
				speedMultiplier = dashSpeed*-1;
			} else if (buttonHeld < dashSpeedInputDuration) {
				speedMultiplier = -1;
			}
			if (grounded)
			{
				facingRight = false;
				transform.Translate(walkspeed*speedMultiplier, 0, 0);
			}
			else if (!grounded)
			{
				transform.Translate(walkspeed*-.85f, 0, 0);
			}
			buttonHeld++;
			Debug.Log("Moving Left");
		}

		//move right
		if (Input.GetKey(KeybindingsScript.Kb.right))
		{
			moveDirection = 1;
			if (buttonHeld >= dashSpeedInputDuration)
			{
				speedMultiplier = dashSpeed;
			} else if (buttonHeld < dashSpeedInputDuration) {
				speedMultiplier = 1;
			}
			if (grounded)
			{
				facingRight = true;
				transform.Translate(walkspeed*speedMultiplier, 0, 0);
			}
			else if (!grounded)
			{
				transform.Translate(walkspeed*.85f, 0, 0);
			}
			buttonHeld++;
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

		//resets when keys are released
		if (Input.GetKeyUp(KeybindingsScript.Kb.left) ||
			Input.GetKeyUp(KeybindingsScript.Kb.right))
		{
			buttonHeld = 0;
			moveDirection = 0;
		}
		if (Input.GetKeyUp(KeybindingsScript.Kb.lightAttack) ||
			Input.GetKeyUp(KeybindingsScript.Kb.mediumAttack))
		{
			action = 0;
		}

		//activate gravity if airborn
		if (!grounded && transform.position.y > -.8f)
		{
			transform.position = getGravity(grounded);
		} else if (transform.position.y <= -.8f) {
			grounded = true;
			transform.position = new Vector2(transform.position.x, -.8f);
			jumpHeight = setJumpHeight;
			airOptions = setAirOptions;
		}
	}

	//jump method, calls gravity
	public Vector2 getJump()
	{
		animator.SetInteger("moveDirection", 2);
		jumpHeight = setJumpHeight;
		grounded = false;
		transform.position = getGravity(grounded);

		Debug.Log("Jumping");
		return transform.position;
	}

	//calculate gravity
	private Vector2 getGravity(bool grounded)
	{
		if (!grounded)
		{
			transform.Translate(0, jumpHeight, 0);
			jumpHeight -= gravity;
		}
		return transform.position;
	}
}