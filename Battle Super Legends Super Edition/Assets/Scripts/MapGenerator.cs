using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public List <int> spawnDirections = new List<int>();
	public List <string> roomExitType = new List<string>();	

	public List <int> xPosition = new List<int>();
	public List <int> yPosition = new List<int>();
	public GameObject roomA;
	public GameObject roomB;
	public GameObject roomC;
	public GameObject roomD;

	public GameObject roomE;
	public GameObject roomF;

	public GameObject roomLeftExitY;
	public GameObject roomRightExitZ;
	public GameObject roomBottomExitYZ;
	public GameObject roomTopExitYZ;


	private int numberOfRooms;

	private int startRoomNum;
	
	private int endRoomNum; 


	// Use this for initialization
	void Start () {
		
		numberOfRooms = Random.Range(1000,2000);
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

			if(spawnDirections[i+1] == 0 && spawnDirections[i] == 0){
				roomExitType.Add("A");
			}
			else if(spawnDirections[i+1] == 2 && spawnDirections[i] == 2){
				roomExitType.Add("A");
			}

			else if (spawnDirections[i+1] == 1 && spawnDirections[i] == 2) {
				roomExitType.Add("B");
			}

			else if(spawnDirections[i+1] == 1 && spawnDirections[i] == 1){
				roomExitType.Add("C");
			}

			else if(spawnDirections[i+1] == 1 && spawnDirections[i] == 0){
				roomExitType.Add("D");
			}
	
			else if (spawnDirections[i+1] == 2 && spawnDirections[i] == 1){
				roomExitType.Add("E");
			}

			else if(spawnDirections[i+1] == 0 && spawnDirections[i] == 1){
				roomExitType.Add("F");
			}
			else{
			Debug.Log(i + " Woopsies Dasies ucky fucky we made an oopsie doopsie.");
		}
		}
		
		roomExitType.Add("Y");
		foreach(string x in roomExitType){
			Debug.Log(x);
		}
	}

	private void PlaceRooms(){
		int xDisplacement = 0;
		int yDisplacement = 0;


			for(int i=0; i < numberOfRooms; i++){
				

				if(roomExitType[i] == "A"){
				Instantiate(roomA, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
				xPosition.Add(xDisplacement);
				yPosition.Add(yDisplacement);
					if(spawnDirections[i] == 0){
						yDisplacement += 10;
					} else {
						yDisplacement -= 10;
					}
				}
				else if(roomExitType[i] == "B"){
					Instantiate(roomB, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);
					xDisplacement += 10;
				}
				else if(roomExitType[i] == "C"){
					Instantiate(roomC, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);					
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "D"){
					Instantiate(roomD, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "E"){
					Instantiate(roomE, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement -= 10;
				}
				else if (roomExitType[i] == "F"){
					Instantiate(roomF, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement+= 10;
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 0){
					Instantiate(roomBottomExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 1){
					Instantiate(roomLeftExitY, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 2){
					Instantiate(roomTopExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}

				
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 1){
					Instantiate(roomRightExitZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 0){
					Instantiate(roomTopExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement += 10;
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 2){
					Instantiate(roomBottomExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement -= 10;
				}
				else {
					Debug.LogError("INVALID SPAWN DIRECTION" + i);
					Debug.Log(roomExitType[i]);
					Debug.Log(spawnDirections[i]);
				}
			}
		}
	}
