using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour {

	public CharactersDatabase callCharactersDatabase = new CharactersDatabase();
	public float fwalk;
	public float bwalk;
	public bool facingRight = true;
	int inputDirection = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (facingRight == true)
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				
				inputDirection = 8;
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				bwalk = callCharactersDatabase.sonicPizzas.backwardSpeed;
				transform.Translate(Vector2.right * bwalk * Time.deltaTime);
				inputDirection = 4;
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				
				inputDirection = 2;
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				fwalk = callCharactersDatabase.sonicPizzas.forwardSpeed;
				transform.Translate(Vector2.left * fwalk * Time.deltaTime);
				inputDirection = 6;
			}

			if (Input.GetKeyUp(KeyCode.None))
			{
				inputDirection = 5;
			}
		}

		if (facingRight == false)
		{
			
		}
	}
}
