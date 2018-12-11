using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private AudioSource source;
    public int colliding=0;
    public float colldown = 0;
    public int player = 0;
    //public GameObject P1;
    //ublic GameObject P2;
    // Use this for initialization
    private void Start()
    {

        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D (Collision2D c) {
        //if(c.collider.tag)
        colliding++;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (c.collider.tag == "Player") //&& c.transform.position.y > -1)
        {
            if (c.gameObject.GetComponent<Animator>().GetInteger("State") == 3)
            {
                if (c.transform.position.x > 0)
                {
                    rb.AddForce(new Vector3(-1f, -0.5f, 0) * 600);
                }
                else
                {
                    rb.AddForce(new Vector3(1f, -0.5f, 0) * 600);
                }
            }
            else
            {
                rb.AddForce(c.contacts[0].normal * 400);
            }
            /*if(c.transform.position.x > 0)
            {
                rb.AddForce(new Vector3(-1f,-0.5f,0) * 500);
            }
            else
            {
                rb.AddForce(new Vector3(1f, -0.5f, 0) * 500);
            }*/
            
            //player++;
        }
        else
        {
            rb.AddForce(c.contacts[0].normal * 400);
        }
        source.Play(0);
    
        Debug.Log(c.gameObject);
	}
    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding--;
        if (collision.collider.tag == "Player")
        {
           // player--;
        }
    }
    private void Update()
    {
        colldown -= Time.deltaTime;
        /*if (colliding > 1 && colldown < 0 && player > 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (gameObject.transform.position.x < 0)
            {
                if(gameObject.transform.position.x < 2)
                {
                    rb.AddForce(new Vector3(0.1f,0.7f,0) * 400);
                }
                else
                {
                    rb.AddForce(new Vector3(-0.5f, 0.7f, 0) * 400);
                }
            }
            else {
                if (gameObject.transform.position.x < -2)
                {
                    rb.AddForce(new Vector3(0.5f, 0.7f, 0) * 400);
                }
                else
                {
                    rb.AddForce(new Vector3(-0.1f, 0.7f, 0) * 400);
                }
            }
            colldown = 0.5f;
        }*/
    }
}
