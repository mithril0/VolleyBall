using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D (Collision2D c) {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(c.contacts[0].normal * 100);

		Debug.Log(rb.velocity);
	}
}
