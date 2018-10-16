using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsController : MonoBehaviour {

	public AudioMixer masterAudioMixer;
	public AudioMixer musicAudioMixer;
	public AudioMixer sfxAudioMixer;

	public Slider masterSlider;
	public Slider musicSlider;
	public Slider sfxSlider;

	Resolution[] resolutions;

	public Dropdown resolutionDropdown;


	public Toggle FullScreenToggle;

	public Resolution resolution;

	List<string> options = new List<string>();

	void Start(){
		masterSlider.value = PlayerPrefs.GetFloat("MasterSlider");
		musicSlider.value = PlayerPrefs.GetFloat("MusicSlider");
		sfxSlider.value = PlayerPrefs.GetFloat("SFXSlider");

		resolution.width = PlayerPrefs.GetInt("ResolutionWidth");
		resolution.height = PlayerPrefs.GetInt("ResolutionHeight");

		
	/*	if(PlayerPrefs.GetInt("FullScreenToggle" , 1) == 1){
			FullScreenToggle.isOn = true;
			Screen.SetResolution(resolution.width, resolution.height, true);
		} else {
			FullScreenToggle.isOn = false;
			Screen.SetResolution(resolution.width, resolution.height, false);
			}
			*/
		dropDownFiller();
	}

	void dropDownFiller(){
				//Debug.Log(PlayerPrefs.GetInt("ResolutionHeight"));
				resolutions = Screen.resolutions;

				
				resolutionDropdown.ClearOptions();

				

				int currentResolutionIndex = 0;
				string option;

				for(int i = 0; i < resolutions.Length; i++){
							//Debug.Log(i + " resolutions " + resolutions[i]);
							option = resolutions[i].width + " x " + resolutions[i].height;
							options.Add(option);
				}
				checkDuplicates();
				checkDuplicates();
				resolutionDropdown.AddOptions(options);
				for(int k = 0; k< options.Count; k++){
					if (System.Convert.ToInt32(options[k].Substring(0 , 4)) == PlayerPrefs.GetInt("ResolutionWidth") && System.Convert.ToInt32(options[k].Substring(7)) == PlayerPrefs.GetInt("ResolutionHeight")){
							currentResolutionIndex = k;
						}
				}
				resolutionDropdown.value = currentResolutionIndex;
				resolutionDropdown.RefreshShownValue();
			//	Debug.Log(PlayerPrefs.GetInt("ResolutionHeight"));
	}

	void checkDuplicates(){
		for(int i = 0; i < options.Count - 1; i++){
			for(int j = i + 1; j < options.Count; j++){
				if(options[i] == options[j]){
					options.RemoveAt(j);
				}
			}
		}
	}
	void Update(){
		PlayerPrefs.SetFloat("MasterSlider", masterSlider.value);
		PlayerPrefs.SetFloat("MusicSlider", musicSlider.value);
		PlayerPrefs.SetFloat("SFXSlider", sfxSlider.value);
		if(FullScreenToggle.isOn == true){
			PlayerPrefs.SetInt("FullScreenToggle", 1);
		} else {
			PlayerPrefs.SetInt("FullScreenToggle", 0);
		}
		
	}

	public void SetResolution (int resolutionIndex){
	
		resolution.width = System.Convert.ToInt32(options[resolutionIndex].Substring(0 , 4));
		resolution.height = System.Convert.ToInt32(options[resolutionIndex].Substring(7));
		PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
		PlayerPrefs.SetInt("ResolutionWidth", resolution.width);


		if(PlayerPrefs.GetInt("FullScreenToggle") == 1){
			FullScreenToggle.isOn = true;
			Screen.SetResolution(resolution.width, resolution.height, true);
		} else {
			FullScreenToggle.isOn = false;
			Screen.SetResolution(resolution.width, resolution.height, false);
		}
		
	}

	public void setMasterVolume(float volume){
		masterAudioMixer.SetFloat("volumeMaster", volume);
	}
		public void setMusicVolume(float volume){
		musicAudioMixer.SetFloat("volumeMusic", volume);
	}
		public void setSFXVolume(float volume){
		sfxAudioMixer.SetFloat("volumeSFX", volume);
	}

		public void setFullScreen(bool isFullscreen){
			Screen.fullScreen = isFullscreen;
		}

		public void returnToMenu(){
			SceneManager.LoadScene(0);
		}
}
