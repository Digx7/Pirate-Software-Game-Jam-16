using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewPlayerSpawnInfoChannel", menuName = "ScriptableObjects/Channels/PlayerSpawnInfo", order = 1)]
public class PlayerSpawnInfoChannel : ScriptableObject
{

    public PlayerSpawnInfoEvent channelEvent = new PlayerSpawnInfoEvent();

    public PlayerSpawnInfo lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue.Clear();
    }
    
    public void Raise(PlayerSpawnInfo value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
