using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    public Transform[] points = new Transform[2];
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, points[0].position.x, points[1].position.x), 0, -10);
    }
}
