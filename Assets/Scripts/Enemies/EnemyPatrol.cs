using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    private bool isSlowed;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private bool isDead = false;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        if(anim != null) anim.SetBool("moving", false);
    }

    private void Update()
    {
        if(isDead) return;
        
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject, 30f);
    }

    public void Slow()
    {
        if(isSlowed) return;
        
        StartCoroutine(SlowTimer());
    }

    IEnumerator SlowTimer()
    {
        isSlowed = true;
        yield return new WaitForSeconds(4f);
        isSlowed = false;
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * GetSpeed(),
            enemy.position.y, enemy.position.z);
    }

    private float GetSpeed()
    {
        if(!isSlowed) return speed;
        else return speed/4;
    }
}
