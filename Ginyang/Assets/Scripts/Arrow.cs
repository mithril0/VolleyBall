using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public GameObject ball;
    public GameObject child;

    private const float arrowHeight = 2.2f;
    private const float ballHeight = 2.9f;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(ball.transform.position.x, arrowHeight,-1);
        if (ball.transform.position.y > ballHeight)
        {
            float s = Scale();
            transform.localScale = new Vector3(s, s, s);
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
	}

    float Scale() {
        float f = (float) (ball.transform.position.y - ballHeight);
        return f < 0 ? 1.2f : 1.2f - Mathf.Min(f/3, 0.4f);
    }
}
