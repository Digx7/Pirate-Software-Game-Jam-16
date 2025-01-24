using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAbilityBoomerang", menuName = "CharacterAbility/Boomerang")]
public class CharacterAbilityBoomerang : CharacterAbility
{
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    void Update() 
    {
        cooldownTimer -= Time.deltaTime;
    }
    public override void Use(PlayerCharacter owner, PlayerCharacter target)
    {
        if(Input.GetKeyDown(KeyCode.J) && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
        }
    }
}
