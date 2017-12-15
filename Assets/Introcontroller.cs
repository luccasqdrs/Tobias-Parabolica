using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introcontroller : MonoBehaviour {

    public Camera camIntro, camPlayer;

    float timeLeft = 28.0f;

    // Use this for initialization
    void Start () {

        FindObjectOfType<AudioManager1>().Play("intro");

        foreach (var cam in Camera.allCameras)
        {
            cam.enabled = false;
        }
        camIntro.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;

        if (timeLeft<0)
        {
            camIntro.enabled = false;
            camPlayer.enabled = true;
        }
	}
}
