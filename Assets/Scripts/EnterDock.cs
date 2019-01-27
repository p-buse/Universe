using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDock : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        gameManager.gameState = GameManager.GameState.docked;
    }
}
