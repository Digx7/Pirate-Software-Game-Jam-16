using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 40f; // Speed of the player

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // Stores the player's movement direction

    void Awake()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the player prefab!");
        }
    }

    void Update()
    {
        // Get input from the player (WASD or arrow keys by default)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to prevent faster diagonal movement
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D
        rb.linearVelocity = movement * moveSpeed;
    }
}
