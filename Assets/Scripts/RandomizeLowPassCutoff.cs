using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioLowPassFilter))]
public class RandomizeLowPassCutoff : MonoBehaviour
{

    public float minCutoff;
    public float maxCutoff;

    private AudioLowPassFilter lowPassFilter;

    // Start is called before the first frame update
    void Start()
    {
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        float cutoff = Random.Range(minCutoff, maxCutoff);
        lowPassFilter.cutoffFrequency = cutoff;
    }
}
