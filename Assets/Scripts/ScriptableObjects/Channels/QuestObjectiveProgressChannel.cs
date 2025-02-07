using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestObjectiveProgressChannel", menuName = "ScriptableObjects/Channels/Quest/ObjectiveProgress", order = 1)]
public class QuestObjectiveProgressChannel : ScriptableObject
{

    public QuestObjectiveProgressEvent channelEvent = new QuestObjectiveProgressEvent();

    public QuestObjectiveProgress lastValue {get; private set;}

    private void OnEnable()
    {
        ResetLastValue();
    }

    public void ResetLastValue()
    {
        lastValue.Clear();
    }
    
    public void Raise(QuestObjectiveProgress value)
    {
        lastValue = value;
        channelEvent.Invoke(value);
    }

    
}
