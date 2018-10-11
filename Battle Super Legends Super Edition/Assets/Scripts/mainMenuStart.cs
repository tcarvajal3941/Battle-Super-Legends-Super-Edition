using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuStart : MonoBehaviour {

	public Resolution resolution;

	// Use this for initialization
	void Awake() {
		resolution.width = PlayerPrefs.GetInt("ResolutionWidth" , 1920);
		resolution.height = PlayerPrefs.GetInt("ResolutionHeight" , 1080);

		if(resolution.height <= 100){
			PlayerPrefs.SetInt("ResolutionHeight", 1080);
		}
		if(resolution.width <= 100){
			PlayerPrefs.SetInt("ResolutionWidth", 1920);
		}
		resolution.width = PlayerPrefs.GetInt("ResolutionWidth" , 1920);
		resolution.height = PlayerPrefs.GetInt("ResolutionHeight" , 1080);

		if(PlayerPrefs.GetInt("FullScreenToggle" , 1) == 1){
			Screen.SetResolution(resolution.width, resolution.height, true);
		} else {
			Screen.SetResolution(resolution.width, resolution.height, false);
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
