﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playscenemanager : MonoBehaviour {
    public int score1;
    //const string First_Pick_Key = "1Player";
    //const string Second_Pick_Key = "2Player";
    public int score2;
    public float delay = 3;
    public float enddelay = -1;
    public int maxscore=15;
    public Text t1;
    public Text t2;
    public bool scored=false;
    public Vector3 prepos;
    public GameObject Ball;
    public GameObject P1;
    public GameObject P2;
    public SpriteRenderer sp1;
    public SpriteRenderer sp2;
    public Rigidbody2D rb;
    public PlayerPrefsManager PP;
    public Animator Ready;

    // Use this for initialization
    void Start () {
       
        rb = Ball.GetComponent<Rigidbody2D>();
        if(PlayerPrefs.GetInt("1Player") ==1) P1 = (GameObject)Instantiate(Resources.Load("Prefabs/cat_P1") as GameObject);
        else if (PlayerPrefs.GetInt("1Player") == 2) P1 = (GameObject)Instantiate(Resources.Load("Prefabs/kai_P1") as GameObject);
        else if (PlayerPrefs.GetInt("1Player") == 3) P1 = (GameObject)Instantiate(Resources.Load("Prefabs/pho_P1") as GameObject);
        if (PlayerPrefs.GetInt("2Player") == 1) P2 = (GameObject)Instantiate(Resources.Load("Prefabs/cat_P2") as GameObject);
        else if (PlayerPrefs.GetInt("2Player") == 2) P2 = (GameObject)Instantiate(Resources.Load("Prefabs/kai_P2") as GameObject);
        else if (PlayerPrefs.GetInt("2Player") == 3) P2 = (GameObject)Instantiate(Resources.Load("Prefabs/pho_P2") as GameObject);
        score1 = 0;
        score2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //if (enddelay > 0)
        //{
         //   enddelay -= Time.deltaTime;
         //   if (enddelay < 0)
         //   {
         //       rb.constraints = RigidbodyConstraints2D.FreezePosition;
         //       Time.timeScale = 1;
          //      Ball.transform.position = prepos;
          //  }
        //}
        if (delay > 0&&enddelay<0)
        {   
            if (score1 > maxscore)
            {
                sp1.sprite = Resources.Load<Sprite>("main_ui/win");
                sp2.sprite = Resources.Load<Sprite>("main_ui/lose");

            }
            else if (score2 > maxscore)
            {
                sp1.sprite = Resources.Load<Sprite>("main_ui/lose");
                sp2.sprite = Resources.Load<Sprite>("main_ui/win");
            }
            else
            {
                Ready.SetTrigger("Ready");
            }
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                if (score1 > maxscore|| score2 > maxscore)
                {
                    PP.SaveAndLoadScene("Start");
                }
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        
        
        t1.text = score1.ToString();
        t2.text = score2.ToString();
	}
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ball")
        {
            //Time.timeScale = 0.5f;
            //enddelay = 0.5f;
            delay = 2;
            //rb.velocity = Vector3.zero;
            Debug.Log(c.gameObject);
            if (c.gameObject.transform.position.x < 0)
            {
                score2++;
                Ball.transform.position = new Vector3(-1.9f, 1f, -0.5f);
                prepos = new Vector3(-2, 2, -0.5f);
            }
            else
            {
                score1++;
                Ball.transform.position = new Vector3(1.9f, 1f, -0.5f);
                prepos = new Vector3(2, 2, -0.5f);

            }
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            //Destroy(Ball);
            //Ball = GameObject.Instantiate(Resources.Load("Prefabs/Ball") as GameObject, prepos,transform.rotation);
            P1.transform.position = new Vector3(-2f, -1.599f, -3f);
            P2.transform.position = new Vector3(2f, -1.599f, -3f);
        }
            
     
    }
}
