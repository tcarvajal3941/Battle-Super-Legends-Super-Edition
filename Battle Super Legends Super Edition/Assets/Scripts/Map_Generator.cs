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
		startRoomNum  = Random.Range(0,3);
		endRoomNum = Random.Range(0,3);

		for(int i = 0 ; i< Rooms.GetLength(0); i++){
			for(int j = 0; j < Rooms.GetLength(1); j++){
				Rooms[i,j] = 0;
				
			}
		}
		Rooms[startRoomNum,0] = -1;
		Rooms[endRoomNum,7] = -2;
		PlaceRooms();
	}
	
	private void PlaceRooms(){
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
