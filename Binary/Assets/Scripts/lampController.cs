using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampController : MonoBehaviour {

	Animator animator;
	string lampState_;
	public GameObject lampTutorial;
	public bool lampSpecial;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(animator.GetInteger("animLamp") == 2){
			animator.SetInteger("animLamp", 1);
		}
		if(lampState_ == "lampInRange"){

			if(Input.GetKeyDown(KeyCode.Z)){

				if(animator.GetInteger("animLamp") == 0){

					CH_Move.playerAction = "TurningObj_On";
					animator.SetInteger("animLamp", 1);
					energyBarController.newCurrentEnergy += 20;
					
				}else if(animator.GetInteger("animLamp") == 1 && energyBarController.newCurrentEnergy >= 20){
					animator.SetInteger("animLamp", 0);
					CH_Move.playerAction = "TurningObj_On";
					energyBarController.newCurrentEnergy -= 20;
				}else if(animator.GetInteger("animLamp") == 1 && energyBarController.newCurrentEnergy < 20){
					animator.SetInteger("animLamp", 2);
					CH_Move.playerAction = "TurningObj_On";
				}
			}
			if(GameController.level == 0){
				lampTutorial.SetActive(true);
			}
		}else if(lampState_ == "lampOutOfRange"){

			if(GameController.level == 0){
				lampTutorial.SetActive(false);
			}
		}
		if(CH_Move.playerAction == "deadByHole"){
			if(lampSpecial == true){

			}else{
				animator.SetInteger("animLamp", 0);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "playerTrigger"){
			Debug.Log("lamp in range...");
			lampState_ = "lampInRange";
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if(coll.gameObject.tag == "playerTrigger"){
			Debug.Log("lamp out of range...");
			lampState_ = "lampOutOfRange";
		}
	}
}
