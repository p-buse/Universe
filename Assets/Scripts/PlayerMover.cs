using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{

    public float moveSpeed = 10f;

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
        // Make the player sprite face the direction of its current velocity.
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void Update()
    {
        if (gameManager.gameState == GameManager.GameState.docked ||
            gameManager.gameState == GameManager.GameState.dragging)
        {
            Dock();
        }
    }

    public void Dock()
    {
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
