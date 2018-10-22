using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReaderMk4 : MonoBehaviour {

	public bool facingOpponent;
	public int  inputDirection;
	public int  inputButton;

	public KeyCode jump;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode light;
	public KeyCode med;
	public KeyCode heavy;
	public KeyCode unique;

	// Use this for initialization
	void Start () {
		facingOpponent = true;
		inputDirection = 5;
		inputButton    = 0;

		jump   = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpkey", "W"));
		down   = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchkey", "S"));
		left   = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftkey", "A"));
		right  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightkey", "D"));
		light  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("lightattackkey", "Y"));
		med    = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("mediumattackkey", "U"));
		heavy  = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("heavyattackkey", "I"));
		unique = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("uniqueattackkey", "K"));
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
		if (facingOpponent == false)
		{
			//walk to the left
			if (Input.GetKey(left))
        	{
				Debug.Log("Walking");
				inputDirection = 6;
        	}
			//walk to the right
        	if (Input.GetKey(right))
        	{
				Debug.Log("Jumping");
				inputDirection = 4;
        	}

			//grounded jump
			if (Input.GetKeyDown(jump))
        	{
				Debug.Log("Jumping");
				inputDirection = 8;
			}
			if (Input.GetKey(jump) && Input.GetKeyDown(left))
			{
				inputDirection = 9;
			}
			if (Input.GetKey(jump) && Input.GetKeyDown(right))
			{
				inputDirection = 7;
			}
			
			//crouch
        	if (Input.GetKey(down))
        	{
				Debug.Log("Crouching");
				inputDirection = 2;
			}
			if (Input.GetKey(down) && Input.GetKey(left))
			{
				Debug.Log("Crouching");
				inputDirection = 3;
			}
			if (Input.GetKey(down) && Input.GetKey(right))
			{
				Debug.Log("Crouching");
				inputDirection = 1;
			}
		}
		if (facingOpponent == true)
		{
			//walk to the left
			if (Input.GetKey(left))
        	{
				inputDirection = 4;
        	}
			//walk to the right
        	if (Input.GetKey(right))
        	{
				inputDirection = 6;
        	}

			//grounded jump
			if (Input.GetKeyDown(jump))
        	{
				inputDirection = 8;
			}
			if (Input.GetKey(jump) && Input.GetKeyDown(left))
			{
				inputDirection = 7;
			}
			if (Input.GetKey(jump) && Input.GetKeyDown(right))
			{
				inputDirection = 9;
			}
			
			//crouch
        	if (Input.GetKey(down))
        	{
				inputDirection = 2;
			}
			if (Input.GetKey(down) && Input.GetKey(left))
			{
				inputDirection = 1;
			}
			if (Input.GetKey(down) && Input.GetKey(right))
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
		if (Input.GetKey(light) || Input.GetKey(light) && Input.GetKey(unique))
		{
			inputButton = 1;//Light (A)
		}
		if (Input.GetKey(med) || Input.GetKey(med) && Input.GetKey(unique))
		{
			inputButton = 2;//Medium (B)
		}
		if (Input.GetKey(heavy) || Input.GetKey(heavy) && Input.GetKey(unique))
		{
			inputButton = 3;//Heavy (C)
		}
		if (Input.GetKey(unique) && !Input.GetKey(light) ||
			Input.GetKey(unique) && !Input.GetKey(med) ||
			Input.GetKey(unique) && !Input.GetKey(heavy))
		{
			inputButton = 4;//Special (S)
		}
		if (Input.GetKey(light) && Input.GetKey(med) || 
			Input.GetKey(light) && Input.GetKey(heavy) || 
			Input.GetKey(med) && Input.GetKey(heavy))
		{
			inputButton = 5;//Throw
		}
		if (Input.GetKey(light) && Input.GetKey(med) && Input.GetKey(heavy))
		{
			inputButton = 6;//Psycho Cancel
		}
		if (Input.GetKey(light) && Input.GetKey(med) && Input.GetKey(heavy) && Input.GetKey(unique))
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
