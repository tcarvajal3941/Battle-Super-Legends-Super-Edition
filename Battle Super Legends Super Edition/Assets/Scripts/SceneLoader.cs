using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	public void startCharacterSelect () {
		
		SceneManager.LoadScene(1);
	}

	public void startSettings(){
		SceneManager.LoadScene(2);
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