using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewUIWidgetDataChannel", menuName = "ScriptableObjects/Channels/UIWidgetData", order = 1)]
public class UIWidgetDataChannel : ScriptableObject
{

    public UIWidgetDataEvent channelEvent = new UIWidgetDataEvent();

    public UIWidgetData lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = null;
    }
    
    public void Raise(UIWidgetData value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
