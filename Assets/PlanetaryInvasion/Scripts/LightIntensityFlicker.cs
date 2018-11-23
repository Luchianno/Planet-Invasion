using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityFlicker : MonoBehaviour {

    Light testLight;
    public float intensityMin = 4.6f;
    public float intensityMax = 5.5f;

    public float frequencyMin = 10.1f;
    public float frequencyMax = 15.3f;

	// Use this for initialization
	void Start () {
		testLight = GetComponent<Light>();
        StartCoroutine(Flicker());
	}
	
	// Update is called once per frame
	IEnumerator Flicker () {
        while (true) {
            float intensity = Random.Range(intensityMin, intensityMax);
            yield return new WaitForSeconds(Random.Range(frequencyMin, frequencyMax));
            testLight.intensity = intensity;
        }
    }
}
