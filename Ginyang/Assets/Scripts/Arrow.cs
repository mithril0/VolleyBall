using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public GameObject ball;
    public GameObject child;
	// Use this for initialization
	void Start () {
        ball = GameObject.Find("ball_1");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position =new Vector3(ball.transform.position.x,2.2f,-1);
        if (ball.transform.position.y > 2.9f)
        {
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
	}
}
