using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float cameraSpeed;
    private Vector3 curentDir;
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 dir = Quaternion.AngleAxis(45, Vector3.up) * new Vector3(inputManager.Axis.x, 0, inputManager.Axis.y);
        curentDir =  Vector3.Lerp(curentDir, dir, cameraSpeed * Time.deltaTime);
        transform.localPosition += curentDir * cameraSpeed * Time.deltaTime;
    }
}