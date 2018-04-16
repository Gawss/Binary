using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH_Move : MonoBehaviour {

	public static string playerAction;
    float speed_x;
	float walkSpeed;
	float speed_y;
	bool jumping;
	public static bool jumpingAttack_Available;

	public float jumpForce;

	Rigidbody2D rb;
	Animator animator;
    void Start ()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		jumping = false;
		jumpingAttack_Available = false;

		playerAction = "Idle";
		walkSpeed = 10.0f;
    }

	void Update(){

		speed_x = Input.GetAxis("Horizontal");
		// speed_y = Input.GetAxis("Vertical");
		// // rb.velocity = new Vector3(speed_x*5.0f, speed_y*25.0f, 0);
		// rb.velocity = new Vector3(speed_x*5.0f, speed_y, 0);


		if(Input.GetAxis("Horizontal") < 0){
			Debug.Log("< 0");
			this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); 
		}else if(Input.GetAxis("Horizontal") > 0){
			Debug.Log("> 0");
			this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); 
		}
		
		else{
			// Debug.Log("animCh = 0");
			animator.SetInteger("animCh", 0);
		}

		if(jumping == false){

			if(Input.GetKey(KeyCode.LeftControl)){
				walkSpeed = 20.0f;
			}else{
				walkSpeed = 10.0f;
			}
			if(Input.GetAxis("Horizontal") != 0){
				// Debug.Log("animCh = 1");
				if(walkSpeed == 20.0f){
					animator.SetInteger("animCh", 5);
				}else{
					animator.SetInteger("animCh", 1);
				}
			}
			rb.velocity = new Vector3(speed_x*walkSpeed, 0, 0);
			if (Input.GetKey(KeyCode.Space)){
				// this.transform.position += new Vector3(0, 0.2f, 0);
				rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
				// rb.velocity = new Vector2(0, 100.0f);
				Debug.Log("Player is jumping...");
				animator.SetInteger("animCh", 2);
				jumping = true;
				jumpingAttack_Available = true;
			}

		}else{
			
			if (Input.GetKey(KeyCode.LeftArrow)){
				// this.transform.position += new Vector3(0, 0.2f, 0);
				rb.AddForce(new Vector2(3.0f*speed_x, 0), ForceMode2D.Impulse);
				// rb.velocity = new Vector2(0, 100.0f);
				Debug.Log("Player is turning left...");
			}
			if (Input.GetKey(KeyCode.RightArrow)){
				// this.transform.position += new Vector3(0, 0.2f, 0);
				rb.AddForce(new Vector2(3.0f*speed_x, 0), ForceMode2D.Impulse);
				// rb.velocity = new Vector2(0, 100.0f);
				Debug.Log("Player is turning right...");
			}
		}
		if(jumpingAttack_Available == true){
			
			if(Input.GetKey(KeyCode.Z)){
				animator.SetInteger("animCh", 3);
			}
		}

		if(playerAction == "TurningObj_On"){
			animator.SetInteger("animCh", 4);
			playerAction = "Idle";
		}
	}
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "platform" || coll.gameObject.tag == "enemyCollider"){
			Debug.Log("Player is in the ground...");
			animator.SetInteger("animCh", 0);
            jumping  = false;
		}

    }
}