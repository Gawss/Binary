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
	private Vector3 offset;
	public Camera mainCam;

	public GameObject energyBar;
	public int startingEnergy;
	public static int currentEnergy;
	public static int newCurrentEnergy;


	// Use this for initialization
	void Start () {
		level = 0;
		initLevel = false;
		offset = mainCam.transform.position - player.transform.position;
		// offset.x = offset.x*10;

		startingEnergy = 50;
		currentEnergy = startingEnergy;
		newCurrentEnergy = currentEnergy;
	}
	
	// Update is called once per frame
	void Update () {

		currentEnergy = (int)energyBar.GetComponent<RectTransform>().sizeDelta.x;
		if(newCurrentEnergy != currentEnergy){
			StartCoroutine("energyBarTransition");
		}		

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
			
		}
	}

	public IEnumerator energyBarTransition() {
		if(newCurrentEnergy > currentEnergy){
			for (float f = currentEnergy; f <= newCurrentEnergy; f += 2.0f) {
				var energyBarRectTransform = energyBar.transform as RectTransform;
				energyBarRectTransform.sizeDelta = new Vector2 (f, 25);
				yield return null;
			}
		}else if(newCurrentEnergy < currentEnergy){
			for (float f = currentEnergy; f >= newCurrentEnergy; f -= 2.0f) {
				var energyBarRectTransform = energyBar.transform as RectTransform;
				energyBarRectTransform.sizeDelta = new Vector2 (f, 25);
				yield return null;
			}
		}
	}	
}
