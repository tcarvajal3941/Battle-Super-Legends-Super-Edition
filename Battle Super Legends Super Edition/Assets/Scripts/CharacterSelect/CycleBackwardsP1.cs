using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBackwardsP1 : MonoBehaviour {

	private int i;
	private SpriteRenderer sr;
	public GameObject characterSelected;

	[SerializeField]
	private Sprite[] sprites; 
	
	private void Start()
	{
		sr = characterSelected.GetComponent<SpriteRenderer>();
		i = 0;
	}

	public void CycleCharacterBackwards()
	{
		sr = characterSelected.GetComponent<SpriteRenderer>();
		sr.sprite = sprites[i];
		i--;
		if (i < 0)
		{
			i = 2;
		}
	}
}