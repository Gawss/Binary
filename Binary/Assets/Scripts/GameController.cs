using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static string enemyAnim_State;
	public static int level;
	public static bool initLevel;
	public GameObject enemyPrefab;
	public GameObject player;
	private Vector3 offset;
	public Camera mainCam;

	// Use this for initialization
	void Start () {
		level = 1;
		initLevel = false;
		offset = mainCam.transform.position - player.transform.position;
		// offset.x = offset.x*10;
	}
	
	// Update is called once per frame
	void Update () {
		mainCam.transform.position = player.transform.position + offset;
		if(initLevel == false){
			if(level == 99){
				for(int generator = 0; generator < 2; generator ++){
					enemyAnim_State = "alive";
					Instantiate(enemyPrefab, new Vector3(-7.42f+generator*10, 0.87f, -0.7f), Quaternion.identity);
				}
			}
			initLevel = true;
		}
	}
}
