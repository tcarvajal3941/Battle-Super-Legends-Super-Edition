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
		
		if(PlayerPrefs.GetInt("FullScreenToggle") == 1){
			FullScreenToggle.isOn = true;
		} else {
			FullScreenToggle.isOn = false;
		}

		masterSlider.value = PlayerPrefs.GetFloat("MasterSlider");
		musicSlider.value = PlayerPrefs.GetFloat("MusicSlider");
		sfxSlider.value = PlayerPrefs.GetFloat("SFXSlider");
		resolution.width = PlayerPrefs.GetInt("ResolutionWidth");
		resolution.height = PlayerPrefs.GetInt("ResolutionHeight");
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		resolutions = Screen.resolutions;

		
		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for(int i = 0; i < resolutions.Length; i++){
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
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
		resolution = resolutions[resolutionIndex];
		PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
		PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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
