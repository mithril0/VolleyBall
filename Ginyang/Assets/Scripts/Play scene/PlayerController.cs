using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode jumpKey = KeyCode.W;
	public KeyCode smashKey = KeyCode.Space;

	private CharacterMovement cm;

	// Use this for initialization
	void Start () {
		cm = GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(leftKey))
			cm.Move(Vector3.left);

		if (Input.GetKey(rightKey))
			cm.Move(Vector3.right);

		if (Input.GetKeyDown(jumpKey))
			cm.StartCoroutine("Jump");

		if (Input.GetKeyDown(smashKey))
			cm.StartCoroutine("Smash");
	}
}
