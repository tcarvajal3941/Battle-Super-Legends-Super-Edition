using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour {

	public int[,] Rooms = new int[3,8];
	public Sprite room1;
	public Sprite room2;
	public Sprite room2WithTop;
	public Sprite room3;

	public int numberOfRooms;

	private int startRoomNum;
	
	private int endRoomNum; 
	// Use this for initialization
	void Start () {
		numberOfRooms = Random.Range(11,20);

		PlaceRooms();
	}
	
	private void PlaceRooms(){
		//0 is up
		//1 is right
		//2 is down
		int nextRoomDirection; //sets to a random number between 0 and 2

	}
	// Update is called once per frame
	void Update () {
		
	}
}
