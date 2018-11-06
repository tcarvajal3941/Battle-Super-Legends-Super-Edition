using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPrefab : MonoBehaviour {
	private float timer = 0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1f * Time.deltaTime;
		if(timer >= 10f){
			Destroy(this.gameObject);	
		}
	}
}

