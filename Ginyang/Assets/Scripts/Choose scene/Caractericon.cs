using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caractericon : MonoBehaviour {
    public bool First;
    public bool Second;
    GameObject temp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        if (First == true){
            if (Second == true)
            {
                temp=gameObject.transform.Find("Purple").gameObject;
                temp.SetActive(true);
            }
            else
            {
                temp = gameObject.transform.Find("Blue").gameObject;
                temp.SetActive(true);
            }

        }
        else if (Second == true)
        {
            temp = gameObject.transform.Find("Red").gameObject;
            temp.SetActive(true);
        }
	}
}
