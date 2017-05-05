using System.Collections;
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
	void Update () {}

    public void playSound(int soundToBePlayed)
    {
        temp = Instantiate(sounds[soundToBePlayed], genRandom(), Quaternion.identity, sphereHolder.transform);
        //sounds[soundToBePlayed].Play();
        temp.Play();
        currentSound = temp;
    }

    Vector3 genRandom()
    {
        float randomCoordinate = Random.Range(-10, 10);
        while (randomCoordinate < 3f && randomCoordinate > -3f)
        {
            randomCoordinate = Random.Range(-10, 10);
        }
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomCoordinate, Random.Range(-5, Screen.height), Random.Range(10, 20)));

        return screenPosition;
    }
}