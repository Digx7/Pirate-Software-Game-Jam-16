using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject slowPrefab;

    public void Shoot()
    {
        Instantiate(slowPrefab, firePoint.position, firePoint.rotation);
    }
}