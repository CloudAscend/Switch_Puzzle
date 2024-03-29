using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{
    public GameObject go;
    private bool activate = false;
    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && activate)
        {
            go.transform.position = transform.position;
            go.transform.localScale *= 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            activate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            activate = false;
    }
}
