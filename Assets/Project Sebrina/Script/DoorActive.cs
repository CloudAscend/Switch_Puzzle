using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActive : MonoBehaviour
{
    public GameObject button;
    public GameObject point;

    private bool act = true;

    private Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (button.GetComponent<SwitchActivate>().activate && act)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
            Invoke("DestroyDoor", 3);
            //button.GetComponent<SwitchActivate>().activate = true;
        }
    }

    private void DestroyDoor()
    {
        act = false;
        rigid.bodyType = RigidbodyType2D.Static;
    }
}
