using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMetronomCubes : MonoBehaviour {

    public GameObject sampleCubePrefab;
    int maxStep = 3;
    GameObject[] metroCube;

    Material[] material;
    public Color inActiveColor;
    public Color activeColor;
    // Use this for initialization
    void Start () {
        material = new Material[maxStep];
        metroCube = new GameObject[maxStep];
        MakeCube();
    }
	
	// Update is called once per frame
	void Update () {
        if (metroCube != null)
        {
            for (int i = 0; i < maxStep; i++)
            {
                metroCube[i].transform.localScale = new Vector3(5, 5, 5);
                material[i].SetColor("_EmissionColor", inActiveColor);
                metroCube[i].transform.localPosition = new Vector3(0 + i, 0, 0);

            }
            metroCube[Metronom.step].transform.localScale = new Vector3(10, 10, 10);
            material[Metronom.step].SetColor("_EmissionColor", activeColor);
        }
	}
    void MakeCube()
    {
        for (int i = 0; i < maxStep; i++)
        {
            GameObject instanceSampleCube = Instantiate(sampleCubePrefab, this.transform);
            //instanceSampleCube.transform.localPosition = new Vector3(0, 0, 0);
            instanceSampleCube.name = "MetroCube" + i;
            instanceSampleCube.transform.position = Vector3.right * i;
            material[i] = instanceSampleCube.GetComponent<MeshRenderer>().materials[0];
            metroCube[i] = instanceSampleCube;
            
        }
        
    }
}
