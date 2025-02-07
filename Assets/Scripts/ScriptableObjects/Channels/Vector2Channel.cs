using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewVector2Channel", menuName = "ScriptableObjects/Channels/Vector2", order = 1)]
public class Vector2Channel : ScriptableObject
{

    public Vector2Event channelEvent = new Vector2Event();

    public Vector2 lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = Vector2.zero;
    }
    
    public void Raise(Vector2 value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }
}
