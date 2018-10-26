using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour {

	Animator anim;
	Collider2D lightCol;
	Collider2D enemyHitBox;
	// Use this for initialization
	void Start () {
		enemyHitBox = GameObject.Find("Capsule").GetComponent<CapsuleCollider2D>();
		foreach(Transform child in transform)
			{
				if(child.name == "LightAttackCollider")
				{
					lightCol = child.GetComponent<BoxCollider2D>();
					lightCol.enabled = false;
				}
			}
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeybindingsScript.Kb.lightAttack)) {
			lightCol.enabled = true;
			if(lightCol.IsTouching(enemyHitBox)){
				capsuleBoi.cp.takeDamage(10);
			}
			anim.SetTrigger("animationTrigger");
			lightCol.enabled = false;
		}
	}
}
