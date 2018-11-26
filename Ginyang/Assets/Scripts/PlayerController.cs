using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode jumpKey = KeyCode.W;

	public float speed = 5;
	public float jumpSpeed = 5;

	private bool isJumping;
	private float ground;

	// Use this for initialization
	void Start () {
		ground = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(leftKey))
			transform.Translate(Vector3.left*speed*Time.deltaTime);

		if (Input.GetKey(rightKey))
			transform.Translate(Vector3.right*speed*Time.deltaTime);

		if (Input.GetKeyDown(jumpKey))
			StartCoroutine("Jump");

	}

	IEnumerator Jump () {
		const float g = 1f;

		if (isJumping == true)
			yield break;

		isJumping = true;

		for(float f = jumpSpeed; transform.position.y >= ground; f -= g) {
			transform.Translate(Vector3.up * f * Time.deltaTime);

			yield return null;
		}

		isJumping = false;

		if (transform.position.y < ground)
				transform.Translate(Vector3.up * (ground-transform.position.y));
	}
}
