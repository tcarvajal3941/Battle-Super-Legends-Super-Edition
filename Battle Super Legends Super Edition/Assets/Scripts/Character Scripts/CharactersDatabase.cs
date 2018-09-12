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
		sonicPizzas.forwardSpeed = .75f;
		sonicPizzas.backwardSpeed = .5f;
		sonicPizzas.characterName = "Sonic Pizzas";

		//man with hat
<<<<<<< HEAD
=======
		manWithHat.health = 12750;
		manWithHat.specialBar = 0;
		manWithHat.forwardSpeed = 10f;
		manWithHat.backwardSpeed = 5f;
		manWithHat.characterName = "Man with Hat";
>>>>>>> 20a6e0973b66dc94ab544f08fd73a5376f4ec9a9
	}
}
