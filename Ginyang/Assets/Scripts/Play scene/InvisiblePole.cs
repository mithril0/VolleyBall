using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision(GameObject.Find("Ball").GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
}
