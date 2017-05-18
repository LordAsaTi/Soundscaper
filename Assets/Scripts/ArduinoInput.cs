using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour {

	public static string input;

    //SerialPort sp = new SerialPort("/dev/cu.wchusbserial1420", 9600);
    SerialPort sp = new SerialPort("COM4", 9600);
    // Use this for initialization
    void Start () {
		sp.Open ();
		sp.ReadTimeout = 1;
        input = "0";
        
	}
	
	// Update is called once per frame
	void Update () {
        if (sp.IsOpen) {
			try {
                //input = sp.ReadLine().ToString();
                StartCoroutine("Example");

                //Debug.Log(sp.ReadLine());

            } catch (System.Exception) {

			} 
		}
	}

    IEnumerator Example()
    {
            input = sp.ReadLine().ToString();
            yield return new WaitForSeconds(0.01f);
        input = "";
            
    }
}
