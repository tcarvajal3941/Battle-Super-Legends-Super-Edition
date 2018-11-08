using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour {

	public GameObject character1;
	private Vector3 myLocation;
	float timer = 0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		myLocation = character1.transform.position;
		if(Input.GetKeyDown(KeybindingsScript.Kb.lightAttack)){
			character1.transform.GetChild(0).gameObject.SetActive(true); 
			timer += 1f * Time.deltaTime;
			if(timer >= .3f){
				character1.transform.GetChild(0).gameObject.SetActive(false); 
			}
			timer =0f;
		}
	}
}



