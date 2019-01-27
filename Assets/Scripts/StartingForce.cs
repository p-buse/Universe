using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingForce : MonoBehaviour
{

    public float x;
    public float y;
    public float randomX;
    public float randomY;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x, y));
        rb.AddForce(new Vector2(Random.Range(-1f*randomX, randomX), Random.Range(-1f*randomY, randomY)));
    }
}
