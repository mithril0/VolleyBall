using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {
    public Slider volumeSlider;
    const string MASTER_VOLUME_KEY = "master_volume";
    const string HIGH_SCORE = "High Score";
    void Start()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY) == false)
        {
            PlayerPrefs.SetFloat("master_volume", 0.5f);
        }
        //musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat("master_volume", volume);
        }
        else
        {
            Debug.LogError("Master Volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);   
    }

    public static void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public void SaveAndLoadScene(string name)
    {
        Time.timeScale = 1;
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        SceneManager.LoadScene(name);
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
