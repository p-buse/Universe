using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    public float interval;
    public float jitter;
    public Transform planetPrefab;
    public float extraDistance = 10f;

    private float timer = 0f;

    float minInterval = 2f;

    private Camera camera;
    private float maxDistanceToEdgeOfScreen;
    private GameManager gameManager;

    private void Start()
    {
        camera = GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Vector3 edgeOfScreen = camera.ScreenToWorldPoint(new Vector3(0f, 0f, camera.nearClipPlane));
        maxDistanceToEdgeOfScreen = Vector3.Distance(transform.position, edgeOfScreen) + extraDistance;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.GameState.docked)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0f;
            interval += Random.Range(-1 * jitter, jitter);
            if (interval < minInterval)
            {
                interval = minInterval;
            }
            Vector2 spawnPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * maxDistanceToEdgeOfScreen;
            Instantiate(planetPrefab, transform.position + new Vector3(spawnPosition.x, spawnPosition.y, 10f), Quaternion.identity);
        }
    }
}
