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
            temp = Instantiate(sounds[soundToBePlayed], genRandom(), Quaternion.identity, sphereHolder.transform);
        }
        else if (explosionHolder != null)
        {
            temp = Instantiate(sounds[soundToBePlayed], genRandomExplosion(), Quaternion.identity, explosionHolder.transform);
        }
        temp.Play();
        currentSound = temp;
    }

    Vector3 genRandom()
    {
        /*
        float randomCoordinate = Random.Range(-10, 10);
        while (randomCoordinate < 3f && randomCoordinate > -3f)
        {
            randomCoordinate = Random.Range(-10, 10);
        }
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomCoordinate, Random.Range(-5, Screen.height), Random.Range(10, 20)));
        */
        Vector3 screenPosition = new Vector3(Random.Range(-9,9), Random.Range(-4.5f, 4.5f), 10);
        return screenPosition;
    }

    Vector3 genRandomExplosion()
    {
        //float randomCoordinate = Random.Range(-10, 10);

        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomCoordinate, Random.Range(-5, Screen.height), Random.Range(250, 500)));
        Vector3 screenPosition = new Vector3(Random.Range(-300, 300), Random.Range(-150, 150f), 300);
        return screenPosition;
    }
}