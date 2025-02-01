using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShoot : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject trapPrefab;

    public void Shoot()
    {
        Instantiate(trapPrefab, firePoint.position, firePoint.rotation);
        Instantiate(trapPrefab, firePoint2.position, firePoint.rotation);
        Instantiate(trapPrefab, firePoint3.position, firePoint.rotation);
    }
}
