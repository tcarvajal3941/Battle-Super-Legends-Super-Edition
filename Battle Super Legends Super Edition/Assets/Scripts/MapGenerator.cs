﻿using System.Collections;
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
		Debug.Log("Number of Rooms = " + numberOfRooms);
		GenerateMap();
		AssignRoomCode();
		PlaceRooms();
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
		roomExitType.Add("Z");
		for (int i = 1; i < numberOfRooms-1; i++){

			if(spawnDirections[i-1] == 0 && spawnDirections[i+1] == 0 && spawnDirections[i] == 0){
				roomExitType.Add("A");
			}
			else if (spawnDirections[i-1] == 2 && spawnDirections[i+1] == 2 && spawnDirections[i] == 0){
				roomExitType.Add("A");
			}
			else if (spawnDirections[i-1] == 1 && spawnDirections[i+1] == 0 && spawnDirections[i] == 0){
				roomExitType.Add("A");
			}



			else if (spawnDirections[i-1] == 2 && spawnDirections[i+1] == 1 && spawnDirections[i] == 2) {
				roomExitType.Add("B");
			}
			else if (spawnDirections[i-1] == 1 && spawnDirections[i+1] == 1 && spawnDirections[i] == 2){
				roomExitType.Add("B");
			}



			else if(spawnDirections[i-1] == 1 && spawnDirections[i+1] == 1 && spawnDirections[i] == 1){
				roomExitType.Add("C");
			}
			else if(spawnDirections[i-1] == 0 && spawnDirections[i+1] == 1 && spawnDirections[i] == 1){
				roomExitType.Add("C");
			}
			else if(spawnDirections[i-1] == 2 && spawnDirections[i+1] == 1 && spawnDirections[i] == 1){
				roomExitType.Add("C");
			}



			else if(spawnDirections[i-1] == 0 && spawnDirections[i+1] == 1 && spawnDirections[i] == 0){
				roomExitType.Add("D");
			}
			else if(spawnDirections[i-1] == 1 && spawnDirections[i+1] == 1 && spawnDirections[i] == 0){
				roomExitType.Add("D");
			}



			else if (spawnDirections[i-1] == 1 && spawnDirections[i+1] == 2 && spawnDirections[i] == 1){
				roomExitType.Add("E");
			}
			else if (spawnDirections[i-1] == 2 && spawnDirections[i+1] == 2 && spawnDirections[i] == 1){
				roomExitType.Add("E");
			}



			else if(spawnDirections[i-1] == 1 && spawnDirections[i+1] == 0 && spawnDirections[i] == 1){
				roomExitType.Add("F");
			}
			else if(spawnDirections[i-1] == 0 && spawnDirections[i+1] == 0 && spawnDirections[i] == 1){
				roomExitType.Add("F");
			}
		}
		roomExitType.Add("Y");
		foreach(string x in roomExitType){
			Debug.Log(x);
		}
	}
	
	private void PlaceRooms(){
		
	}
	void Update () {
		
	}
}
