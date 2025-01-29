using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject boomerangPrefab;


    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(boomerangPrefab, firePoint.position, firePoint.rotation);
    }
}
