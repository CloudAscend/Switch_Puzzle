using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBrush : MonoBehaviour
{
    public GameObject brushCircle;

    private SpearThrow spear;
    private void Start()
    {
        spear = GetComponent<SpearThrow>();
    }

    private void Update()
    {
    }
}
