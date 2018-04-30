using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBarController : MonoBehaviour {


	// public GameObject energyBar;
	public int startingEnergy;
	public static int currentEnergy;
	public static int newCurrentEnergy;
	
	// public GameObject numEnergyBar;
	public Text numEnergy_txt;
	RectTransform energyBarRectTransform;
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
				energyBarRectTransform = this.transform as RectTransform;
				energyBarRectTransform.sizeDelta = new Vector2 (f, 25);
				if(f < 20){
					this.GetComponent<Image>().color = new Color(255, 0, 0);
				}
				else{
					this.GetComponent<Image>().color = new Color(0, 0, 255);
				}
				yield return null;
			}
		}else if(newCurrentEnergy < currentEnergy){
			for (float f = currentEnergy; f >= newCurrentEnergy; f -= 2.0f) {
				energyBarRectTransform = this.transform as RectTransform;
				energyBarRectTransform.sizeDelta = new Vector2 (f, 25);
				if(f < 20){
					this.GetComponent<Image>().color = new Color(255, 0, 0);
				}
				else{
					this.GetComponent<Image>().color = new Color(0, 0, 255);
				}
				yield return null;
			}
		}
	}
}
