using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractZone : MonoBehaviour
{

    public string playerTag = "Player";
    public Channel onPlayerTryInteractChannel;
    public UnityEvent onPlayerEnter;
    public UnityEvent onPlayerLeave;
    public UnityEvent onPlayerInteract;

    private bool isPlayerInZone = false;

    private void OnEnable()
    {
        onPlayerTryInteractChannel.channelEvent.AddListener(TryInteract);
    }

    private void OnDisable()
    {
        onPlayerTryInteractChannel.channelEvent.RemoveListener(TryInteract);
    }

    public void TryInteract()
    {
        if(isPlayerInZone) 
        {
            onPlayerInteract.Invoke();
            Debug.Log("InteractZone: Interact");
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == playerTag) 
        {
            Debug.Log("InteractZone: Player Entered Zone");
            onPlayerEnter.Invoke();
            isPlayerInZone = true;
        }
        else
        {
            Debug.Log("InteractZone: Something else entered");
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == playerTag) 
        {
            Debug.Log("InteractZone: Player Left Zone");
            onPlayerLeave.Invoke();
            isPlayerInZone = false;
        }
        else
        {
            Debug.Log("InteractZone: Something else exited");
        }
    }
}