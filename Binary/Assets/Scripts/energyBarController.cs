using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBarController : MonoBehaviour {


	// public GameObject energyBar;
	public int startingEnergy;
	int currentEnergy;
	public static int newCurrentEnergy;

	// public GameObject numEnergyBar;
	public Text numEnergy_txt;
	// Use this for initialization
	
	void Start () {
		startingEnergy = 10;
		currentEnergy = startingEnergy;
		newCurrentEnergy = currentEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		currentEnergy = (int)this.GetComponent<RectTransform>().sizeDelta.x;
		numEnergy_txt.text = currentEnergy.ToString();
		if(newCurrentEnergy != currentEnergy){
			StartCoroutine("energyBarTransition");
		}	
	}
	public IEnumerator energyBarTransition() {
		if(newCurrentEnergy > currentEnergy){
			for (float f = currentEnergy; f <= newCurrentEnergy; f += 2.0f) {
				var energyBarRectTransform = this.transform as RectTransform;
				energyBarRectTransform.sizeDelta = new Vector2 (f, 25);
				yield return null;
			}
		}else if(newCurrentEnergy < currentEnergy){
			for (float f = currentEnergy; f >= newCurrentEnergy; f -= 2.0f) {
				var energyBarRectTransform = this.transform as RectTransform;
				energyBarRectTransform.sizeDelta = new Vector2 (f, 25);
				yield return null;
			}
		}
	}
}
