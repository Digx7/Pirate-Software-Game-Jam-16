using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewIntChannel", menuName = "ScriptableObjects/Channels/Int", order = 1)]
public class IntChannel : ScriptableObject
{

    public IntEvent channelEvent = new IntEvent();

    public int lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = 0;
    }

    public void Raise(int value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }
}
