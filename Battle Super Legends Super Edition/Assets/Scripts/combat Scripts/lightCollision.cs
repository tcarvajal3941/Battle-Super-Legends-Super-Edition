using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCollision : MonoBehaviour {
	public BoxCollider2D punchCollider;
	public BoxCollider2D enemyCollider;
	private GameObject enemy;
	// Use this for initialization
	void Start () {
		punchCollider = this.GetComponent<BoxCollider2D>();
		enemy = GameObject.Find("Player2").transform.GetChild(0).gameObject;
		enemyCollider = enemy.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(punchCollider.IsTouching(enemyCollider));
		if(punchCollider.IsTouching(enemyCollider)){
			Debug.Log("BIG MEME");
		}
	}
}
