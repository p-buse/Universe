using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    public float interval;
    public float jitter;
    public Transform planetPrefab;

    private float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0f;
            interval += Random.Range(-1 * jitter, jitter);
            Instantiate(planetPrefab, transform.position, Quaternion.identity);
        }
    }
}
