using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -14f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Check if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);

        // If on the ground reset our velocity value
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Debug.Log(velocity);
        // Capture WASD movements on keyboard
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Create the movement vector locally
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply the movement to the Player Controller object
        controller.Move(move * speed * Time.deltaTime);

        // Calculate Y velocity with gravity to the player
        // Use formula: dy = 1/2(g)(t^2)
        velocity.y += gravity * Time.deltaTime;
        // Apply gravity to player
        controller.Move(velocity * Time.deltaTime);
    }
}
