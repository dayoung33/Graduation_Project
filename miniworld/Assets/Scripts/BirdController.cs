using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;
    public Transform Target;
    public Transform BreadPos;
    public Transform RunPos;

    public int HP = 10;

    private bool isAround = false;
    private bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        if(isAround)
        {
            transform.LookAt(Target);
        }
        else
        {
            transform.LookAt(BreadPos);
        }

        if(run)
        {
            transform.LookAt(RunPos);
            transform.position = Vector3.MoveTowards(transform.position, RunPos.position, 0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            if (collision.gameObject.GetComponent<MovableObject>().curState == MovableObject.State.Attack)
            {              
                HP--;
                if(HP <= 0)
                {
                    animator.SetBool("Run",true);
                    run = true;
                }
                else
                {
                    animator.SetFloat("AnimSpeed", 2.0f);
                    animator.SetTrigger("Hit");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isAround = true;
            animator.SetBool("isAround", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAround = false;
            animator.SetBool("isAround", false);
        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, 0.1f);
    }
}
