using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayPeriodicSoundAndBlink : MonoBehaviour
{

    public float minPeriod = 1.0f;
    public float maxPeriod = 5.0f;

    private float timer = 0.0f;
    private float clipLength;
    private Color trueColor;

    // The delay, in seconds, after which the clip will repeat.
    [HideInInspector]
    public float period;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Audio
        audioSource = GetComponent<AudioSource>();
        period = Random.Range(minPeriod, maxPeriod);
        clipLength = audioSource.clip.length;

        // Blinking
        spriteRenderer = GetComponent<SpriteRenderer>();
        trueColor = spriteRenderer.color;
        spriteRenderer.color = Color.white;
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
        spriteRenderer.color = trueColor;
        yield return new WaitForSeconds(clipLength);
        spriteRenderer.color = Color.white;
    }
}
