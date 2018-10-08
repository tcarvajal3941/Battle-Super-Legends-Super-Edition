using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	float fwalk; //pull from other scripts
	float bwalk; //pull from other scripts
	bool facingRight; //pull from other scripts
	float jumpHeight;
	float gravity;

	// Use this for initialization
	void Start () {
		InputReaderMk4 InputReader = gameObject.GetComponent<InputReaderMk4>();
		//CharacterData charData = gameObject.GetComponent<CharacterData>();

		float jumpHeight = 15;
		float gravity = .75f;

		fwalk = 3;
		bwalk = 2;
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		int playerInputDirection;
		playerInputDirection = InputReader.inputDirection;
		
	}
}
