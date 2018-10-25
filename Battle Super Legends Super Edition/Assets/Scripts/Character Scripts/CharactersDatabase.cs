using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersDatabase : MonoBehaviour 
{

	public static CharactersDatabase CD;

	void Start () 
	{
		//sonic pizzas
		

		//man with hat
	}

	public class SonicPizzas : MonoBehaviour
	{
		public static SonicPizzas SP;
		public int health       = 13500;
		public float fwalk      = .05f;
		public float bwalk      = .035f;
		public float jumpHeight = .2f;
		public float gravity    = .01f;
		public int airOptions   = 1;
	}
}
