﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour {

    private AudioSource temp;

    private Camera Camera;
    private int camHeight;
    private int camWidth;

    public AudioSource[] sounds;

    public AudioSource currentSound;

    private GameObject sphereHolder;

	// Use this for initialization
	void Start () {
        sphereHolder = GameObject.Find("SphereHolder");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound(int soundToBePlayed)
    {
        temp = Instantiate(sounds[soundToBePlayed], genRandom(), Quaternion.identity, sphereHolder.transform);
        //sounds[soundToBePlayed].Play();
        temp.Play();
    }

    Vector3 genRandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(RandomCoordinate(), Random.Range(-5, Screen.height), RandomCoordinate()));
        return screenPosition;
    }
    float RandomCoordinate()
    {
        float randomCoordinate = Random.Range(-10, 10);
        while (randomCoordinate < 3f && randomCoordinate > -3f)
        {
            randomCoordinate = Random.Range(-10, 10);
        }
        return randomCoordinate;
    }
}