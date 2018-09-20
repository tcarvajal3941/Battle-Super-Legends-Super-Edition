using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybindingsScript : MonoBehaviour {

	public static KeybindingsScript Kb;
	public KeyCode jump {get; set;}
	public KeyCode crouch {get; set;}
	public KeyCode left {get; set;}
	public KeyCode right {get; set;}
	public KeyCode lightAttack {get; set;}
	public KeyCode mediumAttack {get; set;}
	public KeyCode heavyAttack {get; set;}
	public KeyCode uniqueAttack {get; set;}

	void Awake(){
		if(Kb == null){
			DontDestroyOnLoad(gameObject);
			Kb = this;
		}
		else if (Kb != this){
			Destroy(gameObject);
		}

		jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpkey", "W"));
		crouch = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchkey", "S"));
		left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftkey", "A"));
		right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightkey", "D"));
		lightAttack = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("lightattackkey", "Y"));
		mediumAttack = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("mediumattackkey", "U"));
		heavyAttack = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("heavyattackkey", "I"));
		uniqueAttack = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("uniqueattackkey", "H"));
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
