using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeKeyBinds : MonoBehaviour {

	Transform menuPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;

	bool waitingForKey;


	// Use this for initialization
	void Start () {
		menuPanel = transform.Find("Panel");
		menuPanel.gameObject.SetActive(true);
		waitingForKey = false;

		for(int i = 0; i < 8; i++){
			if(menuPanel.GetChild(i).name == "Light Attack Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.lightAttack.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Medium Attack Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.mediumAttack.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Heavy Attack Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.heavyAttack.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Unique Attack Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.uniqueAttack.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Move Left Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.left.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Move Right Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.right.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Jump Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.jump.ToString();
			}
			else if(menuPanel.GetChild(i).name == "Crouch Button"){
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeybindingsScript.Kb.crouch.ToString();
			}
		}
	}
	
	// Update is called once per frame
	public void resetDefaults(){

	}
	void OnGUI(){
		keyEvent = Event.current;
		if(keyEvent.isKey && waitingForKey){
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void StartAssignment(string keyName){
		if (!waitingForKey){
			StartCoroutine(AssignKey(keyName));
		}
	}
	public void sendText(Text text){
		buttonText = text;
	}

	IEnumerator waitForKey(){
		while(!keyEvent.isKey){
			yield return null;
		}
	}

	public IEnumerator AssignKey(string keyName){
		waitingForKey = true;
		bool repeatKey = false;

		yield return waitForKey();
		for(int i = 0; i < 8; i++){
			if(menuPanel.GetChild(i).name == "Light Attack Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Medium Attack Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Heavy Attack Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Unique Attack Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Move Left Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Move Right Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Jump Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
			else if(menuPanel.GetChild(i).name == "Crouch Button" && menuPanel.GetChild(i).GetComponentInChildren<Text>().text.Equals(newKey)){
				repeatKey = true;
			}
		}
		Debug.Log(repeatKey);
		if(!repeatKey){
			switch(keyName){
				case "jump":
					KeybindingsScript.Kb.jump = newKey;
					buttonText.text = KeybindingsScript.Kb.jump.ToString();
					PlayerPrefs.SetString("jumpkey", KeybindingsScript.Kb.jump.ToString());
					break;
				case "crouch":
					KeybindingsScript.Kb.crouch = newKey;
					buttonText.text = KeybindingsScript.Kb.crouch.ToString();
					PlayerPrefs.SetString("crouchkey", KeybindingsScript.Kb.crouch.ToString());
					break;
				case "left":
					KeybindingsScript.Kb.left = newKey;
					buttonText.text = KeybindingsScript.Kb.left.ToString();
					PlayerPrefs.SetString("leftkey", KeybindingsScript.Kb.left.ToString());
					break;
				case "right":
					KeybindingsScript.Kb.right = newKey;
					buttonText.text = KeybindingsScript.Kb.right.ToString();
					PlayerPrefs.SetString("rightkey", KeybindingsScript.Kb.right.ToString());
					break;
				case "lightattack":
					KeybindingsScript.Kb.lightAttack = newKey;
					buttonText.text = KeybindingsScript.Kb.lightAttack.ToString();
					PlayerPrefs.SetString("lightattackkey", KeybindingsScript.Kb.lightAttack.ToString());
					break;
				case "mediumattack":
					KeybindingsScript.Kb.mediumAttack = newKey;
					buttonText.text = KeybindingsScript.Kb.mediumAttack.ToString();
					PlayerPrefs.SetString("mediumattackkey", KeybindingsScript.Kb.mediumAttack.ToString());
					break;
				case "heavyattack":
					KeybindingsScript.Kb.heavyAttack = newKey;
					buttonText.text = KeybindingsScript.Kb.heavyAttack.ToString();
					PlayerPrefs.SetString("heavyattackkey", KeybindingsScript.Kb.heavyAttack.ToString());
					break;
				case "uniqueattack":
					KeybindingsScript.Kb.uniqueAttack = newKey;
					buttonText.text = KeybindingsScript.Kb.uniqueAttack.ToString();
					PlayerPrefs.SetString("uniqueattackkey", KeybindingsScript.Kb.uniqueAttack.ToString());
					break;
			}
		}

		repeatKey = false;
		yield return null;
	}
}
