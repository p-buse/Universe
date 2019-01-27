using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState { flying, docked, capturing, dragging };
    public GameState gameState = GameState.docked;

    private Vector2 currentMouseCoords;
    private Camera cam;
    private PlayerMover playerMover;
    private HashSet<RotateAroundDock> draggedPlanets = new HashSet<RotateAroundDock>();

    public RaycastHit2D[] underMouse;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerMover = GameObject.Find("Player").GetComponent<PlayerMover>();
    }

    bool inHits(RaycastHit2D[] hits, string objName)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.name == objName)
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        underMouse = Physics2D.RaycastAll(currentMouseCoords, Vector2.zero, Mathf.Infinity);
        if (gameState == GameState.flying)
        {
            if (Input.GetMouseButton(0))
            {
                // Click empty
                if (underMouse.Length == 0)
                {
                    playerMover.Fly();
                }
            }
            if (Input.GetMouseButtonDown(0)) {
                foreach (RaycastHit2D hit in underMouse)
                {
                    if (hit.collider.gameObject.name == "Home")
                    {
                        gameState = GameState.docked;
                    }
                    if (hit.collider.gameObject.name == "Collect")
                    {
                        gameState = GameState.capturing;
                    }
                    if (hit.collider.gameObject.name == "Dock")
                    {
                        gameState = GameState.docked;
                    }
                }

            }
        } else if (gameState == GameState.docked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Click empty
                if (underMouse.Length == 0)
                {
                    gameState = GameState.flying;
                }
                foreach (RaycastHit2D hit in underMouse)
                {
                    if (hit.collider.gameObject.CompareTag("Planet"))
                    {
                        gameState = GameState.dragging;
                        RotateAroundDock rotateAroundDock = hit.collider.gameObject.transform.parent.GetComponent<RotateAroundDock>();
                        if (rotateAroundDock.enabled)
                        {
                            draggedPlanets.Add(rotateAroundDock);
                        }
                    }
                }
            }
        } else if (gameState == GameState.dragging)
        {
            foreach (RotateAroundDock r in draggedPlanets)
            {
                r.DragPlanet();
            }

            if (Input.GetMouseButtonUp(0))
            {
                gameState = GameState.docked;
            }

        } else if (gameState == GameState.capturing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (RaycastHit2D hit in underMouse)
                {
                    if (hit.collider.gameObject.CompareTag("Planet"))
                    {
                        CapturePlanet c = hit.collider.gameObject.GetComponent<CapturePlanet>();
                        if (c)
                        {
                            Debug.Log("Captured planet!");
                            c.Capture();
                        }
                    }
                }
                gameState = GameState.flying;
            }
        }
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
