using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetronomVisualLine : MonoBehaviour {

    RectTransform rectTransform;
    Vector3 startPosition;
    Vector3 target;
    float t;
    float timeToReachTarget = 8;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.position;
        target = GameObject.Find("Endpoint").transform.position;
	}
	
	// Update is called once per frame

        //Asynchron  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! nach einem durchgang
	void Update () {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
        if(transform.position == target)
        {
            transform.position = startPosition;  // hier noch fixen
            Debug.Log("ok");
            t = 0;
        }

    }
}
