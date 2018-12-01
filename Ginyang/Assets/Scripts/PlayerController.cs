using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode jumpKey = KeyCode.W;

	private CharacterMovement cm;

	// Use this for initialization
	void Start () {
		cm = GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(leftKey))
			cm.Move(Vector3.left);

		//if (Input.GetKeyUp(leftKey))
		//	cm.Move(-Vector3.left);

		if (Input.GetKeyDown(rightKey))
			cm.Move(Vector3.right);

		//if (Input.GetKeyUp(rightKey))
		//	cm.Move(-Vector3.right);

		if (Input.GetKeyDown(jumpKey))
			cm.Jump();

	}
}
