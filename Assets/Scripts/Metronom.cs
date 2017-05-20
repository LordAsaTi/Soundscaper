using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronom : MonoBehaviour {

    

    public static int step;
    public int maxStep;
    public bool run = true;

    GameObject line;
    Transform[] checkPoints =  new Transform[9];
    
    bool nextStep = true;
    // Use this for initialization
    void Start () {
        line = GameObject.Find("Line");
        checkPoints[0] = GameObject.Find("StartPoint").transform;
        for (int i = 1; i < 8; i++)
        {
            checkPoints[i] = GameObject.Find("Point"+i).transform;
        }
        checkPoints[8] = GameObject.Find("Endpoint").transform;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (run) {
            if (nextStep) {
                Invoke("StepCounter", 0.5f); //maybe a better way?
                nextStep = false;
            }
        }
        
	}

    void StepCounter()
    {
        if(step < maxStep - 1){
            step++;
        }
        else{
            step = 0;
        }
        nextStep = true;
        Debug.Log(step);
    }
    void Visualize()
    {

    }
}
