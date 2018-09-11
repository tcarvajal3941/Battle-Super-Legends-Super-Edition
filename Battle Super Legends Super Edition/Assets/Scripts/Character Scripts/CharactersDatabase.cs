using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersDatabase : MonoBehaviour 
{
	public Character sonicPizzas = new Character();

	void Start () 
	{
		//sonic pizzas
		sonicPizzas.characterHealth = 100;
		sonicPizzas.specialBar = 0;
		sonicPizzas.forwardSpeed = 10f;
		sonicPizzas.backwardSpeed = 5f;
		sonicPizzas.characterName = "Sonic Pizzas";
	}
}
