using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewGameObjectChannel", menuName = "ScriptableObjects/Channels/GameObject", order = 1)]
public class GameObjectChannel : ScriptableObject
{

    public GameObjectEvent channelEvent = new GameObjectEvent();

    public GameObject lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = null;
    }

    public void Raise(GameObject value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
