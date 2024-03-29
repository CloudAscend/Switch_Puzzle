using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform spear;

    [SerializeField] private Transform player;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        float CameraX = player.position.x;
        float CameraY = player.position.y;

        //transform.position = new Vector3(Mathf.Clamp(CameraX, -4, 100), Mathf.Clamp(CameraY, -9f, 4.5f), -10); //(기본: 54) 수치 조정
        transform.position = new Vector3(CameraX, CameraY, -10);

        mainCamera.orthographicSize -= scroll;

        //5 : 1, 3 : 0.1

    }
}
