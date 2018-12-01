using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float speed = 5;
	public float jumpSpeed = 300;

	private bool isJumping;
	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Ground")
			isJumping = false;
	}

	void OnCollisionExit2D(Collision2D c) {
		if (c.gameObject.tag == "Ground")
			isJumping = true;
	}

	void Update() {
		
	}
	
	public void Move(Vector3 dir) {
		rb.AddForce(transform.InverseTransformDirection(dir) * jumpSpeed);
	}

	public void Jump () {
		if (!isJumping)
			rb.AddForce(transform.InverseTransformDirection(Vector3.up) * jumpSpeed);
	}
}
