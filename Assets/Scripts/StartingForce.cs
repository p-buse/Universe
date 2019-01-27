using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingForce : MonoBehaviour
{

    public float x;
    public float y;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x, y));
    }
}
