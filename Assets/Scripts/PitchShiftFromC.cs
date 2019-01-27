using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class pitch shifts an audio clip a certain amount of scalar steps.
// It assumes your source audio is played on middle C, or 261.63hz.
public class PitchShiftFromC : MonoBehaviour
{
    public int scaleSteps;
    private AudioSource audioSource = null;
    // 2^(1/12), or the constant which multiplied by itself 12 times equals 2.
    readonly float equalTempered = 1.059463094359f;
    readonly float middleC = 261.63f;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning(".Start: Cound't get AudioSource.");
            return;
        }
    }

    private void Update()
    {
        float targetPitch = middleC * Mathf.Pow(this.equalTempered, this.scaleSteps);
        float pitchPercent = targetPitch / middleC;
        this.audioSource.pitch = pitchPercent;
    }
}