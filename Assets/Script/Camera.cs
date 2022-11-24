using UnityEngine;

namespace Script
{ public class Camera : MonoBehaviour
{ private Transform cameraTransform;
    private float rotY;
    private void Awake()
    { cameraTransform = GetComponent<Transform>();
        rotY = cameraTransform.rotation.y;
    } 
    private void Update()
    {
        rotY = 0;
        cameraTransform.rotation = new Quaternion(90f, rotY, 0f, 90);
    }
}}
