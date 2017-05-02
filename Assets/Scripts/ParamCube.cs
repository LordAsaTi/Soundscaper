﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public int band;
    public float startScale;
    public float maxScale;
    public bool useBuffer;

    Material material;
    public Color myColor;

	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (useBuffer){
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] * maxScale) + startScale, transform.localScale.z);
            Color color = new Color(myColor.r * AudioPeer.audioBandBuffer[band], myColor.g * AudioPeer.audioBandBuffer[band], myColor.b * AudioPeer.audioBandBuffer[band], myColor.b * AudioPeer.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        }
        else{
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBand[band] * maxScale) + startScale, transform.localScale.z);
        }
	}
}
