using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampController : MonoBehaviour {

	public GameObject lampTutorial;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.lampState == "lampTutorial_On"){
			lampTutorial.SetActive(true);
		}else{
			lampTutorial.SetActive(false);
		}
	}
}
