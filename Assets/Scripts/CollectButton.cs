using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectButton : MonoBehaviour
{

    public Sprite capturing;
    public Sprite notCapturing;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.GameState.capturing)
        {
            spriteRenderer.sprite = capturing;
        }
        else
        {
            spriteRenderer.sprite = notCapturing;
        }
    }
}
