using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    Animator animator;
    NavMeshAgent nav;
    Rigidbody rigid;

    public enum State { idle, walk, attck, hit, dead, end };

    [SerializeField]
    private State curState = State.idle;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FreezeVelocity()
    {
        rigid.angularVelocity = Vector3.zero;
        rigid.velocity=Vector3.zero;
    }
    private void FixedUpdate()
    {
        FreezeVelocity();
    }
    // Update is called once per frame
    private void Update()
    {
      
        switch (curState)
        {
            case State.idle:
                {
                    float dist = Vector3.Distance(target.position, transform.position);
                    animator.SetBool("IsMove", false);
                    animator.SetBool("IsAttack", false);
                    if (10.0f >= dist)
                    {
                        curState = State.walk;
                    }
                    //curState = State.walk;
                }
                break;

            case State.walk:
                {
                    animator.SetBool("IsMove", true);
                    animator.SetBool("IsAttack", false);
                    nav.SetDestination(target.position);
                    if (!nav.pathPending)
                    {
                        if (nav.remainingDistance <= nav.stoppingDistance)
                        {
                            if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                            {
                                curState = State.attck;
                            }
                        }
                    }
                }
                break;
            case State.attck:
                {
                    animator.SetBool("IsMove", false);
                    animator.SetBool("IsAttack", true);
                    nav.SetDestination(target.position);
                    if (!nav.pathPending)
                    {
                        if (nav.remainingDistance >= nav.stoppingDistance)
                        {
                            if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                            {
                                curState = State.walk;
                            }
                        }
                    }
                }
                break;

        }
    }
}
