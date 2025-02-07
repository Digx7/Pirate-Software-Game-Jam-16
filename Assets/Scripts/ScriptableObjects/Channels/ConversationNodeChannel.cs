using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewConversationNodeChannel", menuName = "ScriptableObjects/Channels/ConversationNode", order = 1)]
public class ConversationNodeChannel : ScriptableObject
{

    public ConversationNodeEvent channelEvent = new ConversationNodeEvent();

    public ConversationNode lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue.Clear();
    }

    public void Raise(ConversationNode value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}