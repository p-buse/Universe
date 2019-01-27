using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAndSound : MonoBehaviour
{
    [System.Serializable]
    public struct Pair
    {
        public Sprite sprite;
        public AudioClip clip;
    }

    public Pair[] pairs;

    void Awake()
    {
        int index = Random.Range(0, pairs.Length);
        Pair p = pairs[index];
        GetComponent<SpriteRenderer>().sprite = p.sprite;
        GetComponent<AudioSource>().clip = p.clip;
    }
}
