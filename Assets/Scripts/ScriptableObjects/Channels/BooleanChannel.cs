using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBooleanChannel", menuName = "ScriptableObjects/Channels/Boolean", order = 1)]
public class BooleanChannel : ScriptableObject
{

    public BooleanEvent channelEvent = new BooleanEvent();

    public bool lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = false;
    }

    public void Raise(bool value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
