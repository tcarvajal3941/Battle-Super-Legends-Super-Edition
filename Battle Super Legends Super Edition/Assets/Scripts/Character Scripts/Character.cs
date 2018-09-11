using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
	public int characterHealth { get; set; }
	public int specialBar { get; set; }
	public float forwardSpeed { get; set; }
	public float backwardSpeed { get; set; }
	public string characterName { get; set; }

	void Start () 
	{
		//check if any of the properties are null. If they are, throw a Debug.LogError
	}	
}