using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleAttackPrefabPlayer1Script : MonoBehaviour {

	public BoxCollider2D lightCollider;

	public BoxCollider2D enemyCollider = GameObject.FindGameObjectWithTag("player2").transform.GetChild(0).GetComponent<BoxCollider2D>();
	public float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1.0f * Time.deltaTime;
		if(timer >= .3){
			GameObject.Destroy(gameObject);
		}
		if(lightCollider.IsTouching(enemyCollider)){
			Debug.Log("HAHAHAHAHHASAHAHHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
		}
	}
}
