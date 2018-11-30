using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public roomData rooms = new roomData();
	public int minRooms = 6;
	public int maxRooms = 9;

	public int minDistanceBetweenRooms =5;
	public int maxDistanceBetweenRooms =12;

	public int maxDrop = -3;
	public int maxJump = 3;

	public int currentLevel;

	private int xCoordinate = 0;


	public GameObject corner;
	public GameObject ground;
	
	// Use this for initialization
	void Start () {
		spawnStartRoom();
	}
	
	void spawnStartRoom(){
		for(int i=0 ; i<16; i++){
			for(int j=0; j<16; j++){
				if(rooms.rd.startRoom[i,j] == 1){
					Instantiate(ground, new Vector2((0 +i + xCoordinate),(0 +j)), Quaternion.identity);
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
