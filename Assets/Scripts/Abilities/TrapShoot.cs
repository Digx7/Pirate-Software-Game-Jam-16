using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShoot : AbilityShoot
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject trapPrefab;

    public void Shoot()
    {
        if(CanShoot())
        {
            StartCoroutine(CoolDown());
        }
        else return;
        
        Instantiate(trapPrefab, firePoint.position, firePoint.rotation);
        Instantiate(trapPrefab, firePoint2.position, firePoint.rotation);
        Instantiate(trapPrefab, firePoint3.position, firePoint.rotation);
    }
}
