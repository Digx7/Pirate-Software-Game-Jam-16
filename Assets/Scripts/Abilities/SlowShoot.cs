using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShoot : AbilityShoot
{
    public Transform firePoint;
    public GameObject slowPrefab;

    public void Shoot()
    {
        if(CanShoot())
        {
            StartCoroutine(CoolDown());
        }
        else return;
        
        Instantiate(slowPrefab, firePoint.position, firePoint.rotation);
    }
}