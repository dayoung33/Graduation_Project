using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform target;
    Animator animator;
    NavMeshAgent nav;
    Rigidbody rigid;
    private int HP = 3;

    public enum State { idle, walk, attck, hit, dead, end };
    public State curState = State.idle;
    private bool QuestInit = false;

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
        if (HP <= 0)
            curState = State.dead;
        StateChange();
    }

    private void StateChange()
    {
        switch (curState)
        {
            case State.idle:
                {
                    float dist = Vector3.Distance(target.position, transform.position);
                    animator.SetBool("IsMove", false);
                    animator.SetBool("IsAttack", false);
                    animator.ResetTrigger("Hit");
                    if (7.0f >= dist)
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
                    animator.ResetTrigger("Hit");
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
                    animator.ResetTrigger("Hit");
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

            case State.dead:
                {
                    nav.Stop();
                    animator.SetBool("isDead", true);
                    if (!QuestInit&&SceneManager.GetActiveScene().name == "SciFi_Industrial_SampleLayout")
                    {
                        GameObject.Find("UISystem").GetComponent<UIManager>().Quest(UIManager.QuestNum.Finish);
                        QuestInit = true;
                    }
                }
                break;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Movable")
        {
            if (collision.gameObject.GetComponent<MovableObject>().curState == MovableObject.State.Attack)
            {
                animator.SetTrigger("Hit");
                HP--;
            }
        }
    }

}
