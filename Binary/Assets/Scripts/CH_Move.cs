using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH_Move : MonoBehaviour {

    float speed;
	Rigidbody2D rb;
    void Start ()
    {
		rb = GetComponent<Rigidbody2D>();
    }

	void Update(){
		speed = Input.GetAxis("Horizontal");
		rb.velocity = new Vector3(speed*1.2f, 0, 0);
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
		// if (Input.GetKey(KeyCode.UpArrow)){
		// 	this.transform.position += new Vector3(0, 0.2f, 0);
		// }
	}
}