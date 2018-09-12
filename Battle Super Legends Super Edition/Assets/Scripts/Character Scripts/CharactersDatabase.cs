using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersDatabase : MonoBehaviour 
{
	public Character sonicPizzas = new Character();

	void Start () 
	{
		//sonic pizzas
		sonicPizzas.health = 13500;
		sonicPizzas.specialBar = 0;
		sonicPizzas.forwardSpeed = .75f;
		sonicPizzas.backwardSpeed = .5f;
		sonicPizzas.characterName = "Sonic Pizzas";

		//man with hat
		manWithHat.health = 12750;
	}
}
