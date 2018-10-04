﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public Transform panel;
	// Use this for initialization
	public void startCharacterSelect () {
		
		SceneManager.LoadScene(1);
	}

	public void startSettings(){
		SceneManager.LoadScene(2);
	}
	public void startSettingsFromKeybinds(){
		panel.gameObject.SetActive(false);
		if(KeybindingsScript.Kb.right != KeyCode.None && KeybindingsScript.Kb.left != KeyCode.None && KeybindingsScript.Kb.jump != KeyCode.None && KeybindingsScript.Kb.crouch != KeyCode.None && KeybindingsScript.Kb.lightAttack != KeyCode.None && KeybindingsScript.Kb.mediumAttack != KeyCode.None && KeybindingsScript.Kb.heavyAttack != KeyCode.None && KeybindingsScript.Kb.uniqueAttack != KeyCode.None){
			SceneManager.LoadScene(2);
		}
		else{
				StartCoroutine(checkBindsFail());
		}
	}

	public IEnumerator checkBindsFail(){
			panel.gameObject.SetActive(true);
			yield return new WaitForSeconds(2);
			panel.gameObject.SetActive(false);
	}
	public void startMapSelect(){

	}

	public void startKeyBindings(){
		SceneManager.LoadScene(3);
	}

	public void quitGame(){
		Application.Quit();
	}
}