﻿using System.Collections;
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
		if (Input.GetKey(leftKey))
			cm.Move(Vector3.left);

		if (Input.GetKey(rightKey))
			cm.Move(Vector3.right);

		if (Input.GetKeyUp(leftKey) || Input.GetKeyUp(rightKey))
			cm.StopMoving();

		if (Input.GetKeyDown(jumpKey))
			cm.StartCoroutine("Jump");

	}
}
