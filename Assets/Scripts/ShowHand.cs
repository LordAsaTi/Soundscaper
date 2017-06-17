using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHand : MonoBehaviour {

    public Text[] text;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

    void SettingText(int IndexBoard)
    {
        if(IndexBoard == 0)
        {
            DefaultABCText();
        }
        if(IndexBoard == 1)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].fontSize = 11;
            }
            text[0].text = "Kick";
            text[1].text = "Clap";
            text[2].text = "Snare";
            text[3].text = "Hi Hat";
            text[4].text = "Hat Open";
            text[5].text = "Stick";
        }
        if(IndexBoard == 2)
        {
            DefaultABCText();
        }
    }
    void DefaultABCText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].fontSize = 14;
        }
        text[0].text = "A";
        text[1].text = "B";
        text[2].text = "C";
        text[3].text = "D";
        text[4].text = "E";
        text[5].text = "F";

    }
}
