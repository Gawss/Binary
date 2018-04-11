using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT1Controller : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.enemyAnim_State == "dead"){
			animator.SetInteger("animEnemy", 1);
			Destroy(GetComponent<BoxCollider2D>());
		}
	}
}
