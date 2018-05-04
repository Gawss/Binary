using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl01Controller : MonoBehaviour {

	public GameObject lamp_1;
	Animator animlamp_1;
	public GameObject lamp_2;
	Animator animlamp_2;
	public GameObject lamp_3;
	Animator animlamp_3;
	public GameObject lamp_4;
	Animator animlamp_4;

	public GameObject buttonRed;
	SpriteRenderer spriteRenderButtonRed;
	// Use this for initialization
	void Start () {

		animlamp_1 = lamp_1.GetComponent<Animator>();
		animlamp_2 = lamp_2.GetComponent<Animator>();
		animlamp_3 = lamp_3.GetComponent<Animator>();
		animlamp_4 = lamp_4.GetComponent<Animator>();

		animlamp_1.SetInteger("animLamp", 1);
		animlamp_2.SetInteger("animLamp", 1);
		animlamp_3.SetInteger("animLamp", 1);
		animlamp_4.SetInteger("animLamp", 1);

		spriteRenderButtonRed = buttonRed.GetComponent<SpriteRenderer>();
		spriteRenderButtonRed.color = Color.gray;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameController.level == 0){
			if(CH_Move.playerAction == "deadByHole"){

				animlamp_1.SetInteger("animLamp", 1);
				animlamp_2.SetInteger("animLamp", 1);
				animlamp_3.SetInteger("animLamp", 1);
				animlamp_4.SetInteger("animLamp", 1);
				spriteRenderButtonRed.color = Color.gray;
			}
			if(animlamp_1.GetInteger("animLamp") == 0 && 
				animlamp_2.GetInteger("animLamp") == 0 &&
				animlamp_3.GetInteger("animLamp") == 0 &&
				animlamp_4.GetInteger("animLamp") == 0){

				spriteRenderButtonRed.color = Color.red;
				// Debug.Log("You win!");
			}else{
				spriteRenderButtonRed.color = Color.gray;
			}
		}
	}
}
