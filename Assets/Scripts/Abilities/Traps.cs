using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Traps : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    private Rigidbody2D rb;
    private bool hasStopped = false;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Ricochet" && hasStopped == false)
        {
            rb.linearVelocity = transform.right * 0;
            hasStopped = true;
        }
        else if(hitInfo.tag == "Enemy")
        {
            Health myEnemy1 = hitInfo.GetComponent<Health>();
            if(myEnemy1 != null)
            {
                myEnemy1.Damage(damage);
            }
        }
    }
}