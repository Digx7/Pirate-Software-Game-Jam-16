using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public float flickForce = 40f;
    public float minFlickForce = 30f;
    public float maxFlickForce = 200f;
    public UnityEvent onStartCharge;
    public UnityEvent onDash;
    public UnityEvent onMoveRight;
    public UnityEvent onMoveLeft;

    private float timeHeld = 0f;
    private bool isHeldDown;

    private bool canMove = true;
    private bool isInMenu = false;
    public void SetIsInMenu(bool value)
    {
        isInMenu = value;
    
        if(isInMenu)
        {
            isHeldDown = false;
            timeHeld = 0;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isHeldDown)  // Left Click Held-Down Timer
        {
            IncreaseTimer();
        }

    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Ground"))
        { 
            canMove = true;
        } 
    } 

    // Called when the player start holding left click
    public void StartCharge()
    {
        isHeldDown = true;
        onStartCharge.Invoke();
    }

    // Called when the player releases holding left click
    public void EndCharge()
    {
        isHeldDown = false;
        if(canMove) Release(); //if canMove then the player is grounded
        timeHeld = 0;
    }

    private void Release()
    {
        canMove = false;

        Debug.Log("Held for " + timeHeld + " seconds"); // CHECK FOR LENGTH OF TIME HELD
        float appliedForce = Mathf.Clamp(timeHeld * flickForce, minFlickForce, maxFlickForce);
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        myRigidbody.linearVelocity = direction * appliedForce * 2;

        onDash.Invoke();
        if(direction.x > 0) onMoveRight.Invoke();
        else if(direction.x < 0) onMoveLeft.Invoke();
    }

    public void IncreaseTimer()
    {
        timeHeld += Time.deltaTime;
    }
}