using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Vector2 scale = transform.localScale;
        Vector2 size = boxCollider.size;
        //boxCollider.size = new Vector2(scale.x, scale.y);
    }
}
