using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT1Controller : MonoBehaviour {

	string enemyAnim_State;
	bool enemyInRange;
	Animator animator;
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
			Destroy(gameObject);
			GameController.initLevel = false;
			// GameController.level = 2;
		}else{
			transform.position = Vector2.MoveTowards(transform.position,  new Vector2(GameController.playerPosition.x ,-1.5f), 2.0f * Time.deltaTime);
			if(CH_Move.jumpingAttack_Available == true){
				if(Input.GetKey(KeyCode.Z)){

					if(enemyInRange == true){
						Debug.Log("Enemy killed...");
						enemyAnim_State = "dead";
					}
					
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D coll){
        if (coll.gameObject.tag == "playerTrigger"){
			enemyInRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll){
        if (coll.gameObject.tag == "playerTrigger"){
			enemyInRange = false;
		}
	}
}
