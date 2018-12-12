using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float speed = 5;
	public float jumpSpeed = 15;

	public float leftLimit;
    public float rightLimit;

	private bool isJumping;
	private bool isSmashing;
	private float ground;
	private Animator ani;
	private float pos_x;
	private float speed_y;

	const float g = 2f;

	// Use this for initialization
	void Start () {
		ground = transform.position.y;
		ani = GetComponent<Animator>();
		pos_x = transform.position.x;
	}

	void Update() {
		if(!isJumping && !isSmashing) {
			if (pos_x != transform.position.x)
				ani.SetInteger("State", 1);
			else
				ani.SetInteger("State", 0);
		}

		pos_x = transform.position.x;
	}
	
	public void Move(Vector3 dir) {
		if ((dir.x < 0 && pos_x > leftLimit) || (dir.x > 0 && pos_x < rightLimit)) 
			transform.Translate(transform.InverseTransformDirection(dir) * speed * Time.deltaTime);
	}

	IEnumerator Smash () {
		if (isSmashing == true)
			yield break;

		isSmashing = true;
		ani.SetInteger("State", 3);

		for(int i=0;i<30;i++)
			yield return null;

		isSmashing = false;
		ani.SetInteger("State", 0);
	}

	IEnumerator Jump () {
		if (isJumping == true)
			yield break;

		isJumping = true;
		ani.SetInteger("State", 2); 

		speed_y = jumpSpeed;

		while(transform.position.y >= ground) {
			float y = transform.position.y + speed_y * Time.deltaTime;
			
			if (!isSmashing || speed_y > 0)
				speed_y -= g * 60 * Time.deltaTime;
			else
				speed_y -= g / 10 * 60 * Time.deltaTime;

			Debug.Log(speed_y);

			transform.Translate((Mathf.Max(y, ground) - transform.position.y) * Vector3.up);

			if(y <= ground)
				break;

			yield return null;
		}

		isJumping = false;
		ani.SetInteger("State", 0); 
	}
}