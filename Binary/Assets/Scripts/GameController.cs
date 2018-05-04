using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public static int level;
	public static bool initLevel;
	public GameObject enemyPrefab;
	public GameObject player;
	public static Vector3 playerPosition;
	public static Vector3 starterPosition;
	private Vector3 offset;
	public Camera mainCam;

	// Use this for initialization
	void Start () {
		level = 0;
		initLevel = false;
		offset = mainCam.transform.position - player.transform.position;
		offset.x = 1;
		playerPosition = starterPosition;

	}
	
	// Update is called once per frame
	void Update () {
	
		playerPosition = player.transform.position;
		mainCam.transform.position = player.transform.position + offset;

		if(initLevel == false){
			if(level == 99){
				for(int generator = 0; generator < 2; generator ++){

					Instantiate(enemyPrefab, new Vector3(-7.42f+generator*10, 0.87f, -0.7f), Quaternion.identity);
				}
			}
			initLevel = true;
		}
		if(level == 0){
			// Vector2.Distance(enemyPrefab.transform.position, player.transform.position);
			starterPosition = new Vector3(-7.69f,1.501593f,-0.7f);
		}
	}
}
