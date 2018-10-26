using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleBoi : MonoBehaviour {

	public static capsuleBoi cp;
	int health = 100;
	void Start () {
		Debug.Log(health);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(health);
	}

	public void takeDamage(int damage){
		
	}
}
