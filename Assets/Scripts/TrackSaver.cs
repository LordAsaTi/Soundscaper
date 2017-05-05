using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSaver : MonoBehaviour {

    //Boolean, dass auf step 0 das recording started 
    bool startBool = true;
    public bool recording = true;

    //Achter takt
    public AudioSource[] saved = new AudioSource[8];
    public int lastSoundPlayed = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!startBool)
        {
            if (!recording)
            {
                if (saved[Metronom.step] != null)
                {
                    if (Metronom.step != lastSoundPlayed)
                    {
                        saved[Metronom.step].Play();
                        lastSoundPlayed = Metronom.step;
                    }
                }
            }
            else
            {
                if (Metronom.step == 7)
                {
                    Invoke("Stop", 1);
                }
            }
        }
        else
        {
            if(Metronom.step == 0)
            {
                startBool = false;
            }
        }
	}

    public void SetTrack(AudioSource _source)
    {
        if (recording) {
            saved[Metronom.step] = _source;
        }
    }

    void Stop()
    {
        recording = false;
    }
}
