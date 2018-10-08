using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderMk4 : MonoBehaviour {

	KeybindingsScript callKeybindingScript = new KeybindingsScript();

	public bool facingRight;
	public int inputDirection;

	// Use this for initialization
	void Start () {
		facingRight = true;
		inputDirection = 5;
	}
	
	// Update is called once per frame
	void Update () {
		getInput(facingRight);
	}

	public int getInput(bool facingRight)
	{
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
		return inputDirection;
	}
}
