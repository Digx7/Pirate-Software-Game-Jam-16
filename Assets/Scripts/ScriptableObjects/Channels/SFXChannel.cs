using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSFXChannel", menuName = "ScriptableObjects/Channels/SFX", order = 1)]
public class SFXChannel : ScriptableObject
{

    public SFXEvent channelEvent = new SFXEvent();

    public string lastValue_name {get; private set;}
    public Vector3 lastValue_location {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue_name = "";
        lastValue_location = Vector3.zero;
    }
    
    public void Raise(string name, Vector3 location)
    {
        lastValue_name = name;
        lastValue_location = location;
        channelEvent.Invoke(name, location);
    }

    
}
