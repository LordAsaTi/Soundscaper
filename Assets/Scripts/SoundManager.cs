﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public GameObject trackSaver;
    public GameObject temp;
    public TrackSaver currentTrackSaver;

    public SoundBoard[] soundBoard;

    private int currentSoundboardIndex;
    public SoundBoard currentSoundboard;

    public Metronom metronom;

    public ShowHand showHand;

    // Use this for initialization
    void Start() {
        metronom = FindObjectOfType<Metronom>();
        showHand = FindObjectOfType<ShowHand>();
    }
	
	// Update is called once per frame
	void Update () {
        SwitchBoard();

        OtherKeys();

        KeyInputs();

        try { ArduinoInputs(); } catch { }
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
            showHand.SendMessage("SettingText", currentSoundboardIndex);
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlaySounds(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySounds(3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySounds(4);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySounds(5);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySounds(6);
        }
    }

    void ArduinoInputs()
    {
        if (ArduinoInput.input.Contains("a"))
        {
            PlaySounds(0);
        }

        if (ArduinoInput.input.Contains("b"))
        {
            PlaySounds(1);
        }
        if (ArduinoInput.input.Contains("c"))
        {
            PlaySounds(2);
        }
        if (ArduinoInput.input.Contains("d"))
        {
            PlaySounds(3);
        }
        if (ArduinoInput.input.Contains("e"))
        {
            PlaySounds(4);
        }
        if (ArduinoInput.input.Contains("f"))
        {
            PlaySounds(5);
        }
        if (ArduinoInput.input.Contains("g"))
        {
            PlaySounds(6);
        }
        if (ArduinoInput.input.Contains("r"))
        {
            temp = Instantiate(trackSaver);
        }
        if (ArduinoInput.input.Contains("s"))
        {
            metronom.run = !metronom.run;
        }




    }

    void OtherKeys()
    {
        //Record
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Record");
            temp = Instantiate(trackSaver);
        }
        //Pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            metronom.run = !metronom.run;
        }
    }
    void PlaySounds(int tracknumber)
    {
        currentSoundboard.playSound(tracknumber);
        if (temp != null) {
            currentTrackSaver = temp.GetComponent<TrackSaver>();
            currentTrackSaver.SetTrack(currentSoundboard.currentSound);
        }
    }
    public int getSoundboardIndex()
    {
        return currentSoundboardIndex;
    }

}
