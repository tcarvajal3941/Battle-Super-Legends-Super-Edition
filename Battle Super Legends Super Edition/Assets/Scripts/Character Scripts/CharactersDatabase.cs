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
		sonicPizzas.health = 100;
		sonicPizzas.specialBar = 0;
		sonicPizzas.forwardSpeed = 10f;
		sonicPizzas.backwardSpeed = 5f;
		sonicPizzas.characterName = "Sonic Pizzas";

		//man with hat
		manWithHat.health = 100;
		manWithHat.specialBar = 0;
		manWithHat.forwardSpeed = 10f;
		manWithHat.backwardSpeed = 5f;
		manWithHat.characterName = "Man with Hat";
	}
}
