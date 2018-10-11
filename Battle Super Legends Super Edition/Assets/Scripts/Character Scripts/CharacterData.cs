using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData{

	string character = "SonicPizzas";
	string calledMove = "5L";

	public float fwalk;
	public float bwalk;
	public int jumpHeight;
	public int doubleJumps;
	public float gravity;

	// Use this for initialization
	void Start () {
		if (character == "SonicPizzas")
		{
			fwalk = 3;
			bwalk = 2;
			jumpHeight = 15;
			doubleJumps = 1;
			gravity = .75f;
			
			if (calledMove == "5L")
			{
				
			}

		}
	}
}
