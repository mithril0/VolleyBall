using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playscenemanager : MonoBehaviour {
    public int score1;
    public int score2;
    public int maxscore;
    public Text t1;
    public Text t2;

    // Use this for initialization
    void Start () {
        score1 = 0;
        score2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        t1.text = score1.ToString();
        t2.text = score2.ToString();
	}
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.transform.position.x < 0)
        {
            score1++;
        }
        else
        {
            score2++;
        }
    }
}
