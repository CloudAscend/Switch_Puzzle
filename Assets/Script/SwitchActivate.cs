using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivate : MonoBehaviour
{
    public Sprite[] pressed;

    public bool activate = false;

    private SpriteRenderer spriter;

    //---TEST---//
    private int objects = 0;

    private void Start()
    {
        spriter = GetComponent<SpriteRenderer>();    
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objects++;
        spriter.sprite = pressed[1];
        activate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objects--;
        if (objects == 0)
        {
            spriter.sprite = pressed[0];
            activate = false;
        }
    }
}
