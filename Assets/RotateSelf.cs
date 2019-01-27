using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{

    public float amount;
    public float randomness;

    private float trueAmount;

    private void Start()
    {
        trueAmount = amount + Random.Range(-1 * randomness, randomness);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, trueAmount));
    }
}
