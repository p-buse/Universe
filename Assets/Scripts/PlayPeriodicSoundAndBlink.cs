using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayPeriodicSoundAndBlink : MonoBehaviour
{

    public float minPeriod = 1.0f;
    public float maxPeriod = 5.0f;

    private float timer = 0f;
    private float clipLength;
    private Color trueColor;

    // The delay, in seconds, after which the clip will repeat.
    [HideInInspector]
    public float period;

    private AudioSource audioSource;

    private void Start()
    {
        // Audio
        audioSource = GetComponent<AudioSource>();
        period = Random.Range(minPeriod, maxPeriod);
        clipLength = audioSource.clip.length;

        // Start by playing and blinking
        timer = period;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > period)
        {
            timer = 0.0f;
            audioSource.Play();
            StartCoroutine(BlinkColor());
        }
    }

    IEnumerator BlinkColor()
    {
        yield return new WaitForSeconds(clipLength);
    }
}
