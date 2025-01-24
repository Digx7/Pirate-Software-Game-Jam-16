using UnityEngine;

public abstract class CharacterAbility : ScriptableObject
{
    public abstract void Use(PlayerCharacter owner, PlayerCharacter target);
}
