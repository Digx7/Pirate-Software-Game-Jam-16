using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSongChannel", menuName = "ScriptableObjects/Channels/Song", order = 1)]
public class SongChannel : ScriptableObject
{

    public SongEvent channelEvent = new SongEvent();

    public SongData lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = null;
    }
    
    public void Raise(SongData value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}