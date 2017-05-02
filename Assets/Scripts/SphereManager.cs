using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

    public GameObject Sphere;

    private SoundManager SoundManager;

    private AudioSource currentSound;

    private Camera Camera;
    private int camHeight;
    private int camWidth;

    // Use this for initialization
    void Start () {
        SoundManager = FindObjectOfType<SoundManager>();

        /*
        for (int i = 0; i < 25; i++) {
            Instantiate(Sphere, genRandom(), Quaternion.identity, transform);
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector3 genRandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Random.Range(Camera.main.nearClipPlane + 1, Camera.main.farClipPlane / 10)));
        return screenPosition;
    }

    public AudioSource getCurrentSound()
    {
        return currentSound;
    }
}
