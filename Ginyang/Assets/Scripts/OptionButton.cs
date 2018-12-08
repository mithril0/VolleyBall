using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour {
    public GameObject Idle;
    public GameObject Option;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OptionClicked()
    {
        Idle.SetActive(false);
        Option.SetActive(true);
    }
    public void GobackGame()
    {
        Idle.SetActive(true);
        Option.SetActive(false);
    }
}
