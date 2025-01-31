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

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When Left Click
        {
            isHeldDown = true;
            onStartCharge.Invoke();
        }

        if (isHeldDown)  // Left Click Held-Down Timer
        {
            timeHeld += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) && canMove)
        {

            canMove = false;
            isHeldDown = false;

            Debug.Log("Held for " + timeHeld + " seconds"); // CHECK FOR LENGTH OF TIME HELD
            float appliedForce = Mathf.Clamp(timeHeld * flickForce, minFlickForce, maxFlickForce);
            
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            myRigidbody.linearVelocity = direction * appliedForce * 2;

            timeHeld = 0; // Reset TimeHeld Timer

            onDash.Invoke();
            if(direction.x > 0) onMoveRight.Invoke();
            else if(direction.x < 0) onMoveLeft.Invoke();

        }

    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Ground"))
        { 
            canMove = true;
        } 
    } 
}