using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherryText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cherry")
        {
            Destroy(other.gameObject);
            cherries++;
            cherryText.text = "Cherry : " + cherries;
        }
    }
}
