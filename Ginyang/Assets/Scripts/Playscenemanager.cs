using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playscenemanager : MonoBehaviour {
    public int score1;
    public int score2;
    public float delay = 0.4f;
    public int maxscore;
    public Text t1;
    public Text t2;
    public bool scored=false;
    public Vector3 prepos;
    public GameObject Ball;
    public GameObject P1;
    public GameObject P2;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        
        score1 = 0;
        score2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (scored == true)
        {
            Time.timeScale = 0.2f;
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                //Ball = GameObject.Find("Ball");
                //Destroy(Ball);
                rb.velocity = Vector2.zero;
                //rb.angularVelocity = Vector3.zero;
                scored = false;
                delay = 0.4f;
                //rb.velocity = new Vector3(0, 0, 0);
                Ball.transform.position = prepos;
                P1.transform.position = new Vector3(-2, -1.599f, -3);
                P2.transform.position = new Vector3(2, -1.599f, -3);
                Time.timeScale = 1;
            }
        }
        t1.text = score1.ToString();
        t2.text = score2.ToString();
	}
    void OnCollisionEnter2D(Collision2D c)
    {

        if (scored == false)
        {
            if (c.gameObject.transform.position.x < 0)
            {
                score2++;
                prepos = new Vector3(-2, 2, -0.5f);
            }
            else
            {
                score1++;
                prepos = new Vector3(2, 2, -0.5f);

            }
            scored = true;
        }
    }
}
