using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewFloatChannel", menuName = "ScriptableObjects/Channels/Float", order = 1)]
public class FloatChannel : ScriptableObject
{

    public FloatEvent channelEvent = new FloatEvent();

    public float lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = 0f;
    }

    public void Raise(float value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
