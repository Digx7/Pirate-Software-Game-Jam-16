using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*BoomerangReturn firePoint2 = hitInfo.GetComponent<BoomerangReturn>();
        if(firePoint2 != null)
        {
            rb.linearVelocity = -transform.right * speed;
        }
        EnemyHealth myEnemy1 = hitInfo.GetComponent<EnemyHealth>();
        if(myEnemy1 != null)
        {
            myEnemy1.TakeDamage(damage);
            Destroy(gameObject, 2);
        }*/
    }
}
