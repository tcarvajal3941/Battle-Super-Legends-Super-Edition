using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatController : MonoBehaviour {
	public Vector3 myLocation;
	public Transform lightAttackPrefab;
	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		myLocation = GameObject.Find("Player").transform.position;
		if(Input.GetKeyDown(KeybindingsScript.Kb.lightAttack)){
			Instantiate(lightAttackPrefab, myLocation, Quaternion.identity);
		}
	}
}



