using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomizeRings : MonoBehaviour
{

    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomSpriteIndex = Random.Range(0, sprites.Length);
        Sprite randomSprite = sprites[randomSpriteIndex] as Sprite;
        spriteRenderer.sprite = randomSprite;
    }

}
