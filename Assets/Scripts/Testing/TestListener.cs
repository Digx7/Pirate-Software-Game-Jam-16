using UnityEngine;

public class TestListener : MonoBehaviour
{
    public IntChannel OnGetCollectableChannel;

    public void OnEnable()
    {
        OnGetCollectableChannel.channelEvent.AddListener(OnGetCollectable);
    }

    public void OnDisable()
    {
        OnGetCollectableChannel.channelEvent.RemoveListener(OnGetCollectable);
    }

    public void OnGetCollectable(int ID)
    {
        Debug.Log("Got Collectable with ID: " + ID);
    }
}
