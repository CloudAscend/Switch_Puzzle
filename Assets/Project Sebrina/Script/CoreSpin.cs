using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSpin : MonoBehaviour
{
    private float spin;
    private void Update()
    {
        spin += 0.5f;
        transform.rotation = Quaternion.Euler(spin, spin, 45);
    }
}
