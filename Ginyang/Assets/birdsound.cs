using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdsound : MonoBehaviour {
    private AudioSource source;
    public float interval;
    public float localtime;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        localtime += Time.deltaTime;
        if (localtime > interval)
        {
            source.Play();
            localtime -= interval;
        }
    }
}
