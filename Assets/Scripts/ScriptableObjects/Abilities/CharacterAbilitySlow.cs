using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAbilitySlow", menuName = "CharacterAbility/Slow")]
public class CharacterAbilitySlow : CharacterAbility
{
    public float enemyMoveSpeed = 60;
    public float speedReduction = 20;
    public override void Use(PlayerCharacter owner, PlayerCharacter target)
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            enemyMoveSpeed = Mathf.Max(enemyMoveSpeed - speedReduction, 0f);
        }
    }
}
