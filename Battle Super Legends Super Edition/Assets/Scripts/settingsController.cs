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


	void Start(){
		dropDownFiller();
	}

	void dropDownFiller(){
				resolution.width = PlayerPrefs.GetInt("ResolutionWidth");
				resolution.height = PlayerPrefs.GetInt("ResolutionHeight");
				
				if(PlayerPrefs.GetInt("FullScreenToggle") == 1){
					FullScreenToggle.isOn = true;
					Screen.SetResolution(resolution.width, resolution.height, true);
				} else {
					FullScreenToggle.isOn = false;
					Screen.SetResolution(resolution.width, resolution.height, false);
				}

				masterSlider.value = PlayerPrefs.GetFloat("MasterSlider");
				musicSlider.value = PlayerPrefs.GetFloat("MusicSlider");
				sfxSlider.value = PlayerPrefs.GetFloat("SFXSlider");
				
				resolutions = Screen.resolutions;

				
				resolutionDropdown.ClearOptions();

				List<string> options = new List<string>();

				int currentResolutionIndex = 0;
				string option;
				Debug.Log(PlayerPrefs.GetInt("ResolutionWidth"));
				Debug.Log(PlayerPrefs.GetInt("ResolutionHeight"));
				for(int i = 0; i < resolutions.Length; i++){
							//Debug.Log(i + " resolutions " + resolutions[i]);
							option = resolutions[i].width + " x " + resolutions[i].height;
							options.Add(option);

					if (resolutions[i].width == PlayerPrefs.GetInt("ResolutionWidth") && resolutions[i].height == PlayerPrefs.GetInt("ResolutionHeight")){
						currentResolutionIndex = i; 
					}
				}
				resolutionDropdown.AddOptions(options);
				resolutionDropdown.value = currentResolutionIndex;
				resolutionDropdown.RefreshShownValue();
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
	//	Debug.Log("Resolutions Index: " + resolutionIndex);
		resolution = resolutions[resolutionIndex];
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
