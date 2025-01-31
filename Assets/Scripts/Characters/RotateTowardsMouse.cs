using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateTowardsMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (lookDirection - (Vector2)transform.position).normalized;
        float lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, lookAngle);
    }
}
