using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH_Move : MonoBehaviour {

    float speed_x;
	float speed_y;
	bool jumping;
	public float jumpForce;
	Rigidbody2D rb;
	Animator animator;
    void Start ()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		jumping = false;
	
    }

	void Update(){

		speed_x = Input.GetAxis("Horizontal");
		// speed_y = Input.GetAxis("Vertical");
		// // rb.velocity = new Vector3(speed_x*5.0f, speed_y*25.0f, 0);
		// rb.velocity = new Vector3(speed_x*5.0f, speed_y, 0);

		if(Input.GetAxis("Horizontal") != 0){
			// Debug.Log("animCh = 1");
			animator.SetInteger("animCh", 1);
			if(Input.GetAxis("Horizontal") < 0){
				this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); 
			}else if(Input.GetAxis("Horizontal") > 0){
				this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); 
			}
		}
		else{
			// Debug.Log("animCh = 0");
			animator.SetInteger("animCh", 0);
		}

		// if (Input.GetKey(KeyCode.LeftArrow)){
		// 	this.transform.position += new Vector3(-0.2f, 0, 0);
		// }
		// if (Input.GetKey(KeyCode.RightArrow)){
		// 	this.transform.Translate(0.2f, 0, 0);
		// }
		// if (Input.GetKey(KeyCode.DownArrow)){
		// 	this.transform.localScale = new Vector3(2, 2.5f, 2);
		// 	if(this.transform.position.y > -0.6f){
		// 		this.transform.position -= new Vector3(0, 0.2f, 0);
		// 	}
		// }
		// if (Input.GetKeyUp (KeyCode.DownArrow)){
		// 	this.transform.localScale = new Vector3(2, 5, 2);
		// }
		if(jumping == false){
			
			rb.velocity = new Vector3(speed_x*10.0f, 0, 0);
			if (Input.GetKey(KeyCode.UpArrow)){
				// this.transform.position += new Vector3(0, 0.2f, 0);
				rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
				// rb.velocity = new Vector2(0, 100.0f);
				Debug.Log("Player is jumping...");
				jumping = true;
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
	}
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "platform")
			Debug.Log("Player is in the ground...");
            jumping  = false;
    }

}