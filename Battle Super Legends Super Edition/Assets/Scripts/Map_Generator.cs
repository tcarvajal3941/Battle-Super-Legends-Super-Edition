using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public List <int> spawnDirections = new List<int>();
	public List <string> roomExitType = new List<string>();	
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

		GenerateMap();
		AssignRoomCode();
	}
	
	private void GenerateMap(){
		//0 is up
		//1 is right
		//2 is down
		int nextRoomDirection;  //sets to a random number between 0 and 2
		int previousRoomDirection = -1;
		for(int i = 0; i < numberOfRooms; i++){
			if(previousRoomDirection == 0){
				nextRoomDirection = Random.Range(0,2);
			}
			else if (previousRoomDirection == 2){
				nextRoomDirection = Random.Range(1,3);
			}
			else {
				nextRoomDirection = Random.Range(0,3);
			}
			previousRoomDirection = nextRoomDirection;
			Debug.Log(nextRoomDirection);
			spawnDirections.Add(nextRoomDirection);
			

		}

	}

	private void AssignRoomCode() {
		roomExitType[0] = "Z";
		roomExitType[numberOfRooms-1] = "Y";
		for (int i = 1; i < numberOfRooms-1; i++){
			if(spawnDirections[i-1] == 0 && spawnDirections[i+1] == 0){
				roomExitType[i] = "A";
			}
			else if(spawnDirections[i-1] == 0 && spawnDirections[i+1] == 1){
				roomExitType[i] = "D";
			}
			else if(spawnDirections[i-1] == 1 && spawnDirections[i+1] == 0){
				roomExitType[i] = "F";
			}
			else if(spawnDirections[i-1] == 1 && spawnDirections[i+1] == 1){
				roomExitType[i] = "C";
			}
			else if (spawnDirections[i-1] == 1 && spawnDirections[i+1] ==2){
				roomExitType[i] = "E";
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
