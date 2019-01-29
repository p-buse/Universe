using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float maxSpeed = 30f;

    private float dockingAnimation = 0f;

    private Rigidbody2D rb;
    private Camera cam;

    private Vector2 currentMouseCoords;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
    }

    // Update is called once per frame
    public void Fly()
    {
        dockingAnimation = 0f;
        Vector2 direction = currentMouseCoords - new Vector2(transform.position.x,
                                                       transform.position.y);
        direction = direction.normalized * moveSpeed;
        rb.AddForce(direction);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        // Make the player sprite face the direction of its current velocity.
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void Update()
    {
        if (gameManager.gameState == GameManager.GameState.docked)
        {
            Dock();
        }
    }

    public void Dock()
    {
        rb.velocity = Vector2.zero;
        if (dockingAnimation < 1f)
        {
            dockingAnimation += Time.deltaTime;
        }
        else
        {
            dockingAnimation = 1f;
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -5), dockingAnimation);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, dockingAnimation);
    }

    void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        currentMouseCoords = cam.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
    }

}
