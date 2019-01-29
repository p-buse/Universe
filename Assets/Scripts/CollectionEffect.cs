using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEffect : MonoBehaviour
{

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float newScale = Mathf.Lerp(transform.localScale.x, 0f, timer);
        if (newScale < 0.01f)
        {
            Destroy(transform.gameObject);
        }
        transform.localScale = new Vector3(newScale, newScale, 1f);
    }
}
