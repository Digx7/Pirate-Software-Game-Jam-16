using UnityEngine;

public class WitchHelper : MonoBehaviour
{
    public Animator animator;

    public void SetTalking(bool value)
    {
        animator.SetBool("Is Talking", value);
    }
}
