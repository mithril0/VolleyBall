using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private AudioSource source;
    // Use this for initialization
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D (Collision2D c) {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(c.contacts[0].normal * 400);
        source.Play(0);

        Debug.Log(rb.velocity);
	}
}
