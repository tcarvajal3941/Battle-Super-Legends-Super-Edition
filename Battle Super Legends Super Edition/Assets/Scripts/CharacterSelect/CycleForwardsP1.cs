using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleForwardsP1 : MonoBehaviour {

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

	public void CycleCharacterForwards()
	{
		if (i > 2)
		{
			i = 0;
			sr.sprite = sprites[i];
			Debug.Log(i);
		}
		else
		{
			sr.sprite = sprites[i];
			++i;
			Debug.Log(i);
		}
	}
}
