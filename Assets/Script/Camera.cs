using UnityEngine;
using UnityEngine.UI;

namespace Script
{ public class Camera : MonoBehaviour
{ private Transform cameraTransform;
    private float speed;
    public Slider cameraSpeed;

    private void Awake()
    { cameraTransform = GetComponent<Transform>(); } 
    private void Update()
    {
        speed = cameraSpeed.value;
        Vector3 Position = cameraTransform.position;
        Position.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        Position.z += Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        cameraTransform.position = Position; }
}}
