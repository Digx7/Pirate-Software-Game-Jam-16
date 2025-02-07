using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewStringChannel", menuName = "ScriptableObjects/Channels/String", order = 1)]
public class StringChannel : ScriptableObject
{
    public StringEvent channelEvent = new StringEvent();

    public string lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = null;
    }
    
    public void Raise(string value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
