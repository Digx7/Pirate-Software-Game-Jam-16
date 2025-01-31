using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Slow : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, 2);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //EnemyMovement myEnemy = hitInfo.GetComponent<EnemyMovement>();
        //if(myEnemy1 != null)
       // {
            //myEnemy.enemySpeed -= 5;
        //}
    }
}