using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSceneManager : MonoBehaviour {
    const string First_Pick_Key = "1Player";
    const string Second_Pick_Key = "2Player";

    public int first;
    public bool pick1=false;
    public bool pick2=false;
    public int second;
    public AudioClip bgm;
    public bool notai = false;
    public GameObject AI;
    public GameObject P1;
    public Bigicon p1;
    public Bigicon p2;
    public GameObject P2;
    public Caractericon Cat;
    public Caractericon Kai;
    public Caractericon Pho;
    private GameObject temp;
    public Animator test;
    private AudioSource source;
    public PlayerPrefsManager PP;
    public float Scenemovedelay = -1;
    public AudioSource change;
    public AudioSource end;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        //AI = GameObject.Find("AI");
        P1 = GameObject.Find("1P");
        p1 = P1.GetComponent<Bigicon>();
        P2 = GameObject.Find("2P");
        p2 = P2.GetComponent<Bigicon>();
        //SecondP.SetActive(false);
        first = 1;
        second = 3;
        Cat = GameObject.Find("CAT").GetComponent<Caractericon>();
        Kai = GameObject.Find("KAI").GetComponent<Caractericon>();
        Pho = GameObject.Find("PHO").GetComponent<Caractericon>();
    }

    // Update is called once per frame
    void Update() {
        if (pick1 && pick2 && Scenemovedelay < 0) { Scenemovedelay = 3; end.PlayDelayed(0.5f); }
        if (Scenemovedelay > 0)
        {
            Scenemovedelay -= Time.deltaTime;
            if (Scenemovedelay < 0)
            {
                PP.SaveAndLoadScene("Play");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pick1 == false)
            {
                pick1 = true;
                PlayerPrefs.SetInt(First_Pick_Key, first);
                test = P1.transform.GetChild(first - 1).GetComponent<Animator>();
                test.SetTrigger("pick");
                source.Play(0);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (pick2 == false)
            {
                PlayerPrefs.SetInt(Second_Pick_Key, second);
                pick2 = true;
                source.Play(0);
                P2.transform.GetChild(second - 1).GetComponent<Animator>().SetTrigger("pick");
            }
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (notai == false)
            {
                P2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("caractericon/bg_select_2P");
                notai = true;
                //AI.SetActive(false);
                P2.SetActive(true);
            }
        }
        if (pick1 == false)
        {
            if (Input.GetKeyDown(KeyCode.A)) { first -= 1; change.Play(); }
            else if (Input.GetKeyDown(KeyCode.D)) {first += 1; change.Play(); }
            if (first > 3) first -= 3; if (first < 1) first += 3;
        }
        if (pick2 == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { second -= 1; change.Play(); }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) {second += 1; change.Play(); }
            if (second > 3) second -= 3; if (second < 1) second += 3;
        }
        Cat.First = Cat.Second = Kai.First = Kai.Second = Pho.First = Pho.Second = p1.cat = p1.pho = p1.kai = p2.cat = p2.kai =p2.pho= false;
        if (first == 1) { Cat.First = true;p1.cat = true; }// temp= gameObject.transform.Find("cat1").gameObject;  }
        else if (first == 2) { Kai.First = true;p1.kai = true; }
        else if (first == 3) { Pho.First = true; p1.pho = true; }

        if (second == 1) { Cat.Second = true; p2.cat = true; }
        else if (second == 2) { Kai.Second = true; p2.kai = true; }
        else if (second == 3) { Pho.Second = true; p2.pho = true; }
    }
    
}
