using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersDatabase : MonoBehaviour 
{
	public Character sonicPizzas = new Character();
	public Character manWithHat = new Character();

	void Start () 
	{
		//sonic pizzas
		sonicPizzas.health = 13500;
		sonicPizzas.specialBar = 0;
		sonicPizzas.forwardSpeed = 3;
		sonicPizzas.backwardSpeed = 2;
		sonicPizzas.characterName = "Sonic Pizzas";

		//man with hat
	}
}
