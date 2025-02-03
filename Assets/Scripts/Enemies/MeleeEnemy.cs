using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    private bool isDead;
    private bool isAttacking = false;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    public UnityEvent OnDamagePlayer;

    //References
    private Animator anim;
    private Health playerHealth; //WE MIGHT DO HEALTH DIFFERENTLY
    // at the time of writing, no player health script has been made
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        if(!isAttacking) cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown && !isAttacking && !isDead)
            {
                cooldownTimer = 0;
                // anim.SetTrigger("meleeAttack");
                StartCoroutine(WindUp());
            }
        }

        if (enemyPatrol != null && !isDead)
            enemyPatrol.enabled = !isAttacking;
    }

    private bool PlayerInSight()
    {
        Vector2 boxOrigin = boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y);
        Vector2 boxDirection = Vector2.left;
        
        RaycastHit2D hit = Physics2D.BoxCast(boxOrigin, boxSize, 0, boxDirection, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector2 boxOrigin = boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y);

        Gizmos.DrawWireCube(boxOrigin, boxSize);
    }

    IEnumerator WindUp()
    {
        isAttacking = true;
        anim.SetBool("windUp", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("windUp", false);
        DamagePlayer();
        isAttacking = false;
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.Damage(damage);
            OnDamagePlayer.Invoke();
        }
    }

    public void Die()
    {
        isDead = true;
        enemyPatrol.Die();
        anim.SetTrigger("die");
        Destroy(gameObject, 5f);
    }
}
