using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderMk4 : MonoBehaviour {

	public bool facingRight;
	public int inputDirection;
	public int inputButton;

	// Use this for initialization
	void Start () {
		facingRight    = true;
		inputDirection = 5;
		inputButton    = 0;

		KeyCode jump   = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpkey"));
		KeyCode down   = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchkey"));
		KeyCode left   = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftkey"));
		KeyCode right  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightkey"));
		KeyCode light  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("lightattackkey"));
		KeyCode med    = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("mediumattackkey"));
		KeyCode heavy  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("heavyattackkey"));
		KeyCode unique = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("uniqueattackkey"));
	}
	
	// Update is called once per frame
	void Update () {
		inputDirection = getInput(facingRight);
		Debug.Log("Input Direction: " + inputDirection);
		inputButton = getButton();
		Debug.Log("Input Button: " + inputButton);
	}

	public int getInput(bool facingRight)
	{
		inputDirection = 5;
		if (facingRight == false)
		{
			//walk to the left
			if (Input.GetKey(KeyCode.left))
        	{
				inputDirection = 6;
        	}
			//walk to the right
        	if (Input.GetKey("right"))
        	{
				inputDirection = 4;
        	}

			//grounded jump
			if (Input.GetKeyDown("up"))
        	{
				inputDirection = 8;
			}
			if (Input.GetKey("up") && Input.GetKeyDown("left"))
			{
				inputDirection = 9;
			}
			if (Input.GetKey("up") && Input.GetKeyDown("right"))
			{
				inputDirection = 7;
			}
			
			//crouch
        	if (Input.GetKey("down"))
        	{
				inputDirection = 2;
			}
			if (Input.GetKey("down") && Input.GetKey("left"))
			{
				inputDirection = 3;
			}
			if (Input.GetKey("down") && Input.GetKey("right"))
			{
				inputDirection = 1;
			}
		}
		if (facingRight == true)
		{
			//walk to the left
			if (Input.GetKey("left"))
        	{
				inputDirection = 4;
        	}
			//walk to the right
        	if (Input.GetKey("right"))
        	{
				inputDirection = 6;
        	}

			//grounded jump
			if (Input.GetKeyDown("up"))
        	{
				inputDirection = 8;
			}
			if (Input.GetKey("up") && Input.GetKeyDown("left"))
			{
				inputDirection = 7;
			}
			if (Input.GetKey("up") && Input.GetKeyDown("right"))
			{
				inputDirection = 9;
			}
			
			//crouch
        	if (Input.GetKey("down"))
        	{
				inputDirection = 2;
			}
			if (Input.GetKey("down") && Input.GetKey("left"))
			{
				inputDirection = 1;
			}
			if (Input.GetKey("down") && Input.GetKey("right"))
			{
				inputDirection = 3;
			}

			//return to idle
			if (!Input.anyKeyDown)
			{
				inputDirection = 5;
			}
		}
		return inputDirection;
	}

	public int getButton()
	{
		inputButton = 0;
		if (Input.GetKey("[4]") || Input.GetKey("[4]") && Input.GetKey("[3]"))
		{
			inputButton = 1;//Light (A)
		}
		if (Input.GetKey("[5]") || Input.GetKey("[5]") && Input.GetKey("[3]"))
		{
			inputButton = 2;//Medium (B)
		}
		if (Input.GetKey("[6]") || Input.GetKey("[6]") && Input.GetKey("[3]"))
		{
			inputButton = 3;//Heavy (C)
		}
		if (Input.GetKey("[3]") && !Input.GetKey("[4]") ||
			Input.GetKey("[3]") && !Input.GetKey("[5]") ||
			Input.GetKey("[3]") && !Input.GetKey("[6]"))
		{
			inputButton = 4;//Special (S)
		}
		if (Input.GetKey("[4]") && Input.GetKey("[5]") || 
			Input.GetKey("[4]") && Input.GetKey("[6]") || 
			Input.GetKey("[5]") && Input.GetKey("[6]"))
		{
			inputButton = 5;//Throw
		}
		if (Input.GetKey("[4]") && Input.GetKey("[5]") && Input.GetKey("[6]"))
		{
			inputButton = 6;//Psycho Cancel
		}
		if (Input.GetKey("[4]") && Input.GetKey("[5]") && Input.GetKey("[6]") && Input.GetKey("[3]"))
		{
			inputButton = 7;//Instant Kill
		}
		if (!Input.anyKeyDown)
		{
			inputButton = 0;
		}
		return inputButton;
	}
}
