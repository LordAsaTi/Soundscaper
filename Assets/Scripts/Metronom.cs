using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronom : MonoBehaviour {

    

    public static int step;
    public int maxStep;
    public bool run = true;
    
    bool nextStep = true;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (run) {
            if (nextStep) {
                Invoke("StepCounter", 1); //maybe a better way?
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
}
