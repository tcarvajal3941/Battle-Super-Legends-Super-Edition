using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject groundTop;
	public GameObject spikes;
	public GameObject bridge;

	public int minPlatformSize = 2;
	public int maxPlatformSize = 12;

	public int maxHazardSize = 3;

	public int platforms = 100;

	public float hazardChance = .5f;

	public float bridgeChance = .1f;

	private int blockNum = 1;
	private int blockHeight;

	private bool isHazard;

	// Use this for initialization
	void Start () {

		Instantiate (groundTop, new Vector2(0,0), Quaternion.identity);

		for(int i=0; i<platforms; i++){
			if(isHazard == true){
				isHazard = false;
			} else {
				if(Random.value < hazardChance){
					isHazard =  true;
				} else {
					isHazard = false;
				}
			}

			if (isHazard) {
				int hazardSize = Mathf.RoundToInt (Random.Range(1, maxHazardSize));
				blockNum += hazardSize;
			} else {

				if(Random.value < bridgeChance){
					int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
					blockHeight = blockHeight + Random.Range(-3, 3);
					
					for(int tiles = 0; tiles<platformSize; tiles++){
						if(tiles == 0 || tiles == platformSize-1){
							Instantiate (groundTop, new Vector2(blockNum,blockHeight),Quaternion.identity);
						}
						Instantiate(bridge, new Vector2(blockNum,blockHeight), Quaternion.identity);
						blockNum++;
					}
					} else {

					//platform generation
					int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
					blockHeight = blockHeight + Random.Range(-3, 3);
					
					for(int tiles = 0; tiles<platformSize; tiles++){
						Instantiate(groundTop, new Vector2(blockNum,blockHeight), Quaternion.identity);
						blockNum++;
					}
				} 
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
