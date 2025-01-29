using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject slowPrefab;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(slowPrefab, firePoint.position, firePoint.rotation);
    }
}