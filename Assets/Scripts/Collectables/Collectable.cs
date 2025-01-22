using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collectable : MonoBehaviour
{
    public string PlayerTag = "Player";
    public int ID;
    public IntChannel OnGetCollectableChannel;
    
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == PlayerTag)
        {
            OnCollect();
        }
    }

    private void OnCollect()
    {
        OnGetCollectableChannel.Raise(ID);
        Destroy(gameObject);
    }
}
