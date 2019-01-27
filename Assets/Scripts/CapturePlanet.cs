using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePlanet : MonoBehaviour
{

    public float minRadius = 2f;
    public float maxRadius = 8f;

    private Transform dock;
    private RotateAroundDock rotateAroundDock;

    // Start is called before the first frame update
    void Start()
    {
        dock = GameObject.Find("Dock").transform;
        rotateAroundDock = transform.parent.GetComponent<RotateAroundDock>();
    }

    public void Capture()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        float randomMagnitude = Random.Range(minRadius, maxRadius);
        transform.parent.position = dock.position + (randomPosition * randomMagnitude);
        rotateAroundDock.enabled = true;
    }

}
