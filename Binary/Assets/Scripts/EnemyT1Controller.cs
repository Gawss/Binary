using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT1Controller : MonoBehaviour {

	string enemyAnim_State;
	bool enemyInRange;
	Animator animator;

	public GameObject pressToKill_Img;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		enemyAnim_State = "alive";
		enemyInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyAnim_State == "dead"){
			animator.SetInteger("animEnemy", 1);
			// Destroy(gameObject);
			GameController.initLevel = false;
			// GameController.level = 2;
		}else{
			// transform.position = Vector2.MoveTowards(transform.position,  new Vector2(GameController.playerPosition.x ,-1.8f), 2.0f * Time.deltaTime);
			transform.position += -transform.right * Time.deltaTime *2f;
			if(CH_Move.jumpingAttack_Available == true){
				if(Input.GetKey(KeyCode.X)){

					if(enemyInRange == true){
						energyBarController.newCurrentEnergy += 10;
						Debug.Log("Enemy killed...");
						pressToKill_Img.SetActive(false);
						enemyAnim_State = "dead";
					}
					
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D coll){
        if (coll.gameObject.tag == "playerTrigger"){
			Debug.Log("enemyInRange");
			if(enemyAnim_State == "alive"){
				pressToKill_Img.SetActive(true);
			}
			enemyInRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll){
        if (coll.gameObject.tag == "playerTrigger"){
			Debug.Log("enemyOutRange");
			if(enemyAnim_State == "alive"){
				pressToKill_Img.SetActive(false);
			}
			enemyInRange = false;
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "enemyMoveLimiter"){
			Debug.Log("changeDir");
			transform.Rotate(0, 180, 0);
		}
	}
	void OnCollisionStay2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			if(enemyAnim_State == "alive"){
				if(energyBarController.newCurrentEnergy > 0){
					energyBarController.newCurrentEnergy -= 1;
				}
			}
		}
	}
}
