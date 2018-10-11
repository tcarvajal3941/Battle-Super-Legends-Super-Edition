using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleForwards : MonoBehaviour {

	private int i;
	private SpriteRenderer sr;
	public GameObject characterSelected;

	[SerializeField]
	private Sprite[] sprites; 
	

	public void CycleCharacterForwards()
	{
		sr = characterSelected.GetComponent<SpriteRenderer>();
		for(i = 0; i < sprites.Length; i++)
		{
			sr.sprite = sprites[i]; //finsih this
		}
	}
}
