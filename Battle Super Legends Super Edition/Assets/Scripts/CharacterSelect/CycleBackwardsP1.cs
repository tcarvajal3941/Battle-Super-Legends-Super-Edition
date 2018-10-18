using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBackwardsP1 : MonoBehaviour {

	protected CycleForwardsP1 cycle = new CycleForwardsP1();
	private SpriteRenderer sr;
	public GameObject characterSelected;

	[SerializeField]
	private List<Sprite> sprites; 
	
	private void Start()
	{
		sr = characterSelected.GetComponent<SpriteRenderer>();
	}

	public void CycleCharacterBackwards()
	{
		if (cycle.characterIndex > 0)
		{
			cycle.characterIndex--;
			sr.sprite = sprites[cycle.characterIndex];
			Debug.Log(cycle.characterIndex);
		}
		else 
		{
			cycle.characterIndex = 2;
			sr.sprite = sprites[2];
			Debug.Log(cycle.characterIndex);
		}
	}
}
