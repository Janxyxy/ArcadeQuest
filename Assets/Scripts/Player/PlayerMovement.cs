using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private int maxXRotation;

    private CharacterController controller;
    private float xRotation = 0f;
    private Vector3 velocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (MenuManager.IsMenuOpen) 
            return;

        Move();
        Look();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller.isGrounded)
        {
            velocity.y = 0f; 
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move((move * speed + velocity) * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxXRotation, maxXRotation);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
