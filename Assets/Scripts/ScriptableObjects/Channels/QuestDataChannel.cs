using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestDataChannel", menuName = "ScriptableObjects/Channels/Quest/Data", order = 1)]
public class QuestDataChannel : ScriptableObject
{

    public QuestDataEvent channelEvent = new QuestDataEvent();

    public QuestData lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue = null;
    }
    
    public void Raise(QuestData value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
