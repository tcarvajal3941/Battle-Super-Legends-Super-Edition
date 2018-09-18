using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CycleThruMapsRight : MonoBehaviour {

	private int i;
	public void CycleForwards()
	{
		i = SceneManager.GetActiveScene().buildIndex;
		if (i < 5)
		{
			SceneManager.LoadScene(++i);
		} 
		else 
		{
			i = 2;
			SceneManager.LoadScene(i);
		}
	}

}
