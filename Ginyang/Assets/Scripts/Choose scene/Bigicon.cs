using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigicon : MonoBehaviour {
    public bool cat;
    public bool pho;
    public bool kai;
    GameObject temp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     //   foreach (Transform child in transform)
       //     child.gameObject.SetActive(false);
        if (cat == true)
        {
            temp = gameObject.transform.Find("cat").gameObject;
            temp.SetActive(true);
            temp = gameObject.transform.Find("pho").gameObject;
            temp.SetActive(false);
            temp = gameObject.transform.Find("kai").gameObject;
            temp.SetActive(false);
        }
        else if (pho == true)
        {
            temp = gameObject.transform.Find("cat").gameObject;
            temp.SetActive(false);
            temp = gameObject.transform.Find("pho").gameObject;
            temp.SetActive(true);
            temp = gameObject.transform.Find("kai").gameObject;
            temp.SetActive(false);
        }
        else if (kai == true)
        {
            temp = gameObject.transform.Find("cat").gameObject;
            temp.SetActive(false);
            temp = gameObject.transform.Find("pho").gameObject;
            temp.SetActive(false);
            temp = gameObject.transform.Find("kai").gameObject;
            temp.SetActive(true);
        }
    }
}
