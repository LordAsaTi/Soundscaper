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

    public GameObject sphereHolder;
    public GameObject explosionHolder;

	// Use this for initialization
	void Start () {
        //sphereHolder = GameObject.Find("SphereHolder");
	}
	
	// Update is called once per frame
	void Update () {}

    public void playSound(int soundToBePlayed)
    {
        if (sphereHolder != null) {
            temp = Instantiate(sounds[soundToBePlayed], genRandomSphere(), Quaternion.identity, sphereHolder.transform);
        }
        else if (explosionHolder != null)
        {
            temp = Instantiate(sounds[soundToBePlayed], genRandomExplosion(), Quaternion.identity, explosionHolder.transform);
        }

        //sounds[soundToBePlayed].Play();
        temp.Play();
        currentSound = temp;
    }

    Vector3 genRandomSphere()
    {
        float randomCoordinate = Random.Range(-10, 10);
        while (randomCoordinate < 3f && randomCoordinate > -3f)
        {
            randomCoordinate = Random.Range(-10, 10);
        }
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomCoordinate, Random.Range(-5, Screen.height), Random.Range(10, 20)));

        return screenPosition;
    }

    Vector3 genRandomExplosion()
    {
        float randomCoordinate = Random.Range(-10, 10);

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomCoordinate, Random.Range(-5, Screen.height), Random.Range(250, 500)));

        return screenPosition;
    }
}