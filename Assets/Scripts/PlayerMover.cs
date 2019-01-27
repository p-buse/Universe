using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{

    public float moveSpeed = 10f;

    private Rigidbody2D rb;
    private Camera cam;

    private Vector2 currentMouseCoords;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 direction = currentMouseCoords - new Vector2(transform.position.x,
                                                                 transform.position.y);
            direction = direction.normalized * moveSpeed;
            rb.AddForce(direction);
        }
        // Make the player sprite face the direction of its current velocity.
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        currentMouseCoords = cam.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
    }

}
