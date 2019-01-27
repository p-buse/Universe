using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoopSound : MonoBehaviour
{

    public float minPeriod = 1.0f;
    public float maxPeriod = 5.0f;

    private float timer = 0.0f;

    // The delay, in seconds, after which the clip will repeat.
    [HideInInspector]
    public float period;

    private AudioSource audioSource;

    private void Start()
    {
        period = Random.Range(minPeriod, maxPeriod);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > period)
        {
            timer = 0.0f;
            audioSource.Play();
        }
    }
}
