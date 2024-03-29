using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
