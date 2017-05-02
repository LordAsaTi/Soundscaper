using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSaver : MonoBehaviour {

    public int metronomeStep;

    public bool recording = true;

    //Achter takt
    private AudioSource[] saved = new AudioSource[8];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!recording)
        {
            //Loop tracks
        }
        else
        {

        }
	}

    public void SetTrack(AudioSource _source)
    {
        saved[metronomeStep] = _source;
    }
}
