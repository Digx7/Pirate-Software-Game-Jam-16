using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance { get; private set; }
    public List<CharacterAbility> Abilities;

    public PlayerCharacter CharacterPrefab;
    
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
