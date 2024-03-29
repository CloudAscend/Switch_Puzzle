using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingTest : MonoBehaviour
{
    public float mouseSpeed = 10.0f;

    private float cameraSize;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        cameraSize = mainCamera.orthographicSize;
    }

    private void FixedUpdate()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * mouseSpeed;
        mainCamera.orthographicSize -= scroll;
        Mathf.Clamp(mainCamera.orthographicSize, 3, 12);
    }
}
