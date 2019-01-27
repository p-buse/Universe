using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateThrust : MonoBehaviour
{
    public float thrustInterval = 0.1f;

    private float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer > thrustInterval)
            {
                timer = 0f;
                Transform thrustCopy = Instantiate(transform, transform.position, transform.rotation);
                thrustCopy.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
