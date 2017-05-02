using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public GameObject trackSaver;
    public GameObject temp;
    public TrackSaver currentTrackSaver;

    public SoundBoard[] soundBoard;

    private int currentSoundboardIndex;
    public SoundBoard currentSoundboard;

    public

    // Use this for initialization
    void Start() {}
	
	// Update is called once per frame
	void Update () {
        SwitchBoard();

        OtherKeys();

        KeyInputs();
	}

    void SwitchBoard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSoundboardIndex++;

            if (currentSoundboardIndex >= soundBoard.Length)
            {
                currentSoundboardIndex = 0;
            }

            currentSoundboard = soundBoard[currentSoundboardIndex];
        }
    }

    void KeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySounds(0);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            PlaySounds(1);
        }
    }

    void OtherKeys()
    {
        //Record
        if(Input.GetKeyDown(KeyCode.R))
        {
            temp = Instantiate(trackSaver);
        }
    }
    void PlaySounds(int tracknumber)
    {
        currentSoundboard.playSound(tracknumber);
        currentTrackSaver = temp.GetComponent<TrackSaver>();
        currentTrackSaver.SetTrack(currentSoundboard.currentSound);
    }

}
