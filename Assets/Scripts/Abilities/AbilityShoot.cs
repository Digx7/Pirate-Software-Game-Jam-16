using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShoot : MonoBehaviour
{
    public bool isUnlocked = false;
    public float recastTime = 1f;
    private bool isCoolingDown;

    private void Awake()
    {
        isCoolingDown = false;
    }

    public bool CanShoot()
    {
        if(!isUnlocked)
        {
            Debug.Log("Tried to use a locked ability");
            return false;
        }

        if(isCoolingDown)
        {
            Debug.Log("Ability is on cooldown");
            return false;
        }

        return true;
    }

    public IEnumerator CoolDown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(recastTime);
        isCoolingDown = false;
    }
}
