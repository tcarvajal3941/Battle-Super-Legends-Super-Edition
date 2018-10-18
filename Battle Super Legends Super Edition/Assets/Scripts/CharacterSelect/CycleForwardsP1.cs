using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleForwardsP1 : MonoBehaviour {

	public int characterIndex;
	private SpriteRenderer sr;
	public GameObject characterSelected;

	[SerializeField]
	private List<Sprite> sprites; 
	
	private void Start()
	{
		sr = characterSelected.GetComponent<SpriteRenderer>();
	}

	public void CycleCharacterForwards()
	{
		if (characterIndex < 2)
		{
			characterIndex++;
			sr.sprite = sprites[characterIndex];
			Debug.Log(characterIndex);
		}
		else 
		{
			characterIndex = 0;
			sr.sprite = sprites[0];
			Debug.Log(characterIndex);
		}
	}
}
