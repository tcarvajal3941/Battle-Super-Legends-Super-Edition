using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CycleThroughMapsLeft : MonoBehaviour {

	private int i;
	public void CycleBackwards()
	{
		i = SceneManager.GetActiveScene().buildIndex;
		if (i > 2)
		{
			SceneManager.LoadScene(--i);
		} 
		else 
		{
			i = 5;
			SceneManager.LoadScene(i);
		}
	}
}
