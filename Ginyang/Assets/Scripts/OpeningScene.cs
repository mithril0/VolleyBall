using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpeningScene : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "master_volume";
    public float delay = 3;
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetFloat("master_volume", 0.5f);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            SceneManager.LoadScene("Start");
        }
	}
}
