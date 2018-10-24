using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderMk4 : MonoBehaviour {

	public static InputReaderMk4 GM1;
	public bool facingOpponent;
	public int  inputDirection;
	public int  inputButton;

	// Use this for initialization
	void Awake () {
		facingOpponent = true;
		inputDirection = 5;
		inputButton    = 0;
	}
	
	// Update is called once per frame
	void Update () {
		inputDirection = getInput(facingOpponent);
		Debug.Log("Input Direction: " + inputDirection);
		inputButton = getButton();
		Debug.Log("Input Button: " + inputButton);
	}

	public int getInput(bool facingOpponent)
	{
		inputDirection = 5;
		if (!facingOpponent)
		{
			//walk to the left
			if (Input.GetKey(KeybindingsScript.Kb.left))
        	{
				
				inputDirection = 6;
        	}
			//walk to the right
        	if (Input.GetKey(KeybindingsScript.Kb.right))
        	{
				inputDirection = 4;
        	}

			//grounded jump
			if (Input.GetKey(KeybindingsScript.Kb.jump))
        	{
				inputDirection = 8;
			}
			if (Input.GetKey(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.left))
			{
				inputDirection = 9;
			}
			if (Input.GetKey(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.right))
			{
				inputDirection = 7;
			}
			
			//crouch
        	if (Input.GetKey(KeybindingsScript.Kb.crouch))
        	{
				inputDirection = 2;
			}
			if (Input.GetKey(KeybindingsScript.Kb.crouch) && Input.GetKey(KeybindingsScript.Kb.left))
			{
				inputDirection = 3;
			}
			if (Input.GetKey(KeybindingsScript.Kb.left) && Input.GetKey(KeybindingsScript.Kb.right))
			{
				inputDirection = 1;
			}
		}
		if (facingOpponent)
		{
			//walk to the left
			if (Input.GetKey(KeybindingsScript.Kb.left))
        	{
				Debug.Log("WE DID IT REDDIT YEAH BOIIIIIIIIIIIIIIIIIIIIIIIIII ");
				inputDirection = 4;
        	}
			//walk to the right
        	if (Input.GetKey(KeybindingsScript.Kb.right))
        	{
				Debug.Log("WE DID IT REDDIT YEAH BOIIIIIIIIIIIIIIIIIIIIIIIIII ");
				inputDirection = 6;
        	}

			//grounded jump
			if (Input.GetKey(KeybindingsScript.Kb.jump))
        	{
				Debug.Log("WE DID IT REDDIT YEAH BOIIIIIIIIIIIIIIIIIIIIIIIIII ");
				inputDirection = 8;
			}
			if (Input.GetKey(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.left))
			{
				inputDirection = 7;
			}
			if (Input.GetKey(KeybindingsScript.Kb.jump) && Input.GetKey(KeybindingsScript.Kb.right))
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
		}
		return inputDirection;
	}

	public int getButton()
	{
		inputButton = 0;
		if (Input.GetKey(KeybindingsScript.Kb.lightAttack) || 
			Input.GetKey(KeybindingsScript.Kb.lightAttack) && Input.GetKey(KeybindingsScript.Kb.uniqueAttack))
		{
			inputButton = 1;//Light (A)
		}
		if (Input.GetKey(KeybindingsScript.Kb.mediumAttack) || 
			Input.GetKey(KeybindingsScript.Kb.mediumAttack) && Input.GetKey(KeybindingsScript.Kb.uniqueAttack))
		{
			inputButton = 2;//Medium (B)
		}
		if (Input.GetKey(KeybindingsScript.Kb.heavyAttack) || 
			Input.GetKey(KeybindingsScript.Kb.heavyAttack) && Input.GetKey(KeybindingsScript.Kb.uniqueAttack))
		{
			inputButton = 3;//Heavy (C)
		}
		if (Input.GetKey(KeybindingsScript.Kb.uniqueAttack) && !Input.GetKey(KeybindingsScript.Kb.lightAttack) ||
			Input.GetKey(KeybindingsScript.Kb.uniqueAttack) && !Input.GetKey(KeybindingsScript.Kb.mediumAttack) ||
			Input.GetKey(KeybindingsScript.Kb.uniqueAttack) && !Input.GetKey(KeybindingsScript.Kb.heavyAttack))
		{
			inputButton = 4;//Special (S)
		}
		if (Input.GetKey(KeybindingsScript.Kb.lightAttack) && Input.GetKey(KeybindingsScript.Kb.mediumAttack) || 
			Input.GetKey(KeybindingsScript.Kb.lightAttack) && Input.GetKey(KeybindingsScript.Kb.heavyAttack) || 
			Input.GetKey(KeybindingsScript.Kb.mediumAttack) && Input.GetKey(KeybindingsScript.Kb.heavyAttack))
		{
			inputButton = 5;//Throw
		}
		if (Input.GetKey(KeybindingsScript.Kb.lightAttack) && 
			Input.GetKey(KeybindingsScript.Kb.mediumAttack) && Input.GetKey(KeybindingsScript.Kb.heavyAttack))
		{
			inputButton = 6;//Psycho Cancel
		}
		if (Input.GetKey(KeybindingsScript.Kb.lightAttack) && Input.GetKey(KeybindingsScript.Kb.mediumAttack) &&
			Input.GetKey(KeybindingsScript.Kb.heavyAttack) && Input.GetKey(KeybindingsScript.Kb.uniqueAttack))
		{
			inputButton = 7;//Instant Kill
		}
		return inputButton;
	}
}
