using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //EnemyMovement myEnemy = hitInfo.GetComponent<EnemyMovement>();
        //if(myEnemy1 != null)
       // {
            //myEnemy.enemySpeed -= 5;
            Destroy(gameObject, 2);
        //}
    }
}