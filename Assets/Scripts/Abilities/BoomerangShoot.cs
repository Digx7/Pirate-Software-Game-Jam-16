using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangShoot : AbilityShoot
{
    public Transform firePoint;
    public GameObject boomerangPrefab;

    public void Shoot()
    {
        if(CanShoot())
        {
            StartCoroutine(CoolDown());
        }
        else return;
        
        Instantiate(boomerangPrefab, firePoint.position, firePoint.rotation);
    }
}
