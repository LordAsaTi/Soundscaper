using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {


    //Spawnt nur in einem Kreuzbereich, ändern?

    public int band = 0;
    private static float startScale = 1;
    private static float maxScale = 5;

    private AudioSource currSound;
    private float dataMultiplier = 1000;
    public static float[] buffer = new float[8];
    private float[] bufferDecrease = new float[8];

    float[] spectrum = new float[512];
    public static float[] freqBand = new float[8];

    float[] freqBandHighest = new float[8];
    public static float[] audioBand = new float[8];
    public float[] audioBandBuffer = new float[8];

    public ParticleSystem effect;
    private bool effectPlayed;

    // Use this for initialization
    void Start () {
        currSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (currSound.isPlaying)
        {
            if (!effectPlayed)
            {
                effect.Play();
                effectPlayed = true;
            }
            //currSound.GetOutputData(spectrum, 0);

            currSound.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
            MakeFrequencyBands();

            useBuffer();
            createAudioBands();

            //transform.localScale = new Vector3((audioBandBuffer[band] * maxScale) + startScale, (audioBandBuffer[band] * maxScale) + startScale, (audioBandBuffer[band] * maxScale) + startScale);
            
        }
        else {
            effect.Stop();
            effectPlayed = false;
            transform.localScale = Vector3.zero;
        }
    }

    void useBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqBand[g] > buffer[g])
            {
                buffer[g] = freqBand[g];
                bufferDecrease[g] = 0.005f;
            }
            if (freqBand[g] < buffer[g])
            {
                buffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }
    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2; //power = 2 hoch i

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += spectrum[count] * (count + 1);
                count++;
            }
            average /= count;
            freqBand[i] = average * 10;

        }
    }
    void createAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (buffer[i] / freqBandHighest[i]);
        }
    }
}
