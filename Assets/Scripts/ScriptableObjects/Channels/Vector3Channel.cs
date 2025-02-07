using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewVector3Channel", menuName = "ScriptableObjects/Channels/Vector3", order = 1)]
public class Vector3Channel : ScriptableObject
{
    public Vector3Event channelEvent = new Vector3Event();

    public Vector3 lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = Vector3.zero;
    }
    
    public void Raise(Vector3 value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }
}
