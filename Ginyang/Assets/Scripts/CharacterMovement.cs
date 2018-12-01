using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float speed = 5;
	public float jumpSpeed = 15;

	private bool isJumping;
	private float ground;

	const float g = 2f;

	// Use this for initialization
	void Start () {
		ground = transform.position.y;
	}
	
	public void Move(Vector3 dir) {
		transform.Translate(dir * speed * Time.deltaTime);
	}

	IEnumerator Jump () {
		if (isJumping == true)
			yield break;

		isJumping = true;

		float f = jumpSpeed;

		while(transform.position.y >= ground) {
			float y = transform.position.y + f * Time.deltaTime;
			f -= g;

			transform.Translate((Mathf.Max(y, ground) - transform.position.y) * Vector3.up);

			if(y < ground)
				break;

			yield return null;
		}

		isJumping = false;
	}
}