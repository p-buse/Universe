using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundDock : MonoBehaviour
{

    private GameObject dock;

    public float radius = 10f;
    public float rotateSpeedMultiplier = 1f;

    public float angle;
    private Vector3 screenPoint;
    private bool isDragged = false;


    void ResetPosition()
    {
        angle = Vector2.SignedAngle(dock.transform.position, transform.position) * Mathf.Deg2Rad;
        radius = Vector2.Distance(dock.transform.position, transform.position);
    }

    private void Start()
    {
        dock = GameObject.Find("Dock");
        ResetPosition();
    }

    void Update()
    {
        // Rotate around the planet
        Vector2 center = dock.transform.position;
        angle += rotateSpeedMultiplier * (1 / Mathf.Pow(radius, 2)) * Time.deltaTime;
        Vector2 delta = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + delta;
    }


    public void DragPlanet()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = new Vector3(curPosition.x, curPosition.y, 0f);
        ResetPosition();
    }

}