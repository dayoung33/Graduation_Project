using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;
    public Transform Target;
    public Transform BreadPos;
    public Transform RunPos;
    public AudioClip HitAudio;
    public AudioClip RunAudio;

    private AudioSource audio;


    public int HP = 5;

    [SerializeField]
    private bool isAround = false;
    private bool run = false;
    private bool InitRunSound = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = HitAudio;
    }

    // Update is called once per frame
    void Update()
    {
        ///////치트키////////
        if (Input.GetKeyDown(KeyCode.F3))
        {
            HP = -1;
            animator.SetBool("Run", true);
            run = true;         
        }


        if (isAround)
        {
            transform.LookAt(Target);
        }
        else
        {
            transform.LookAt(BreadPos);
        }

        if(run)
        {
            if(!InitRunSound)
            {
                audio.Stop();
                audio.clip = RunAudio;
                audio.Play();
                InitRunSound = true;
            }
            transform.LookAt(RunPos);
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = Vector3.MoveTowards(transform.position, RunPos.position, 1.2f * Time.deltaTime);
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
                    animator.SetBool("isAround", false);
                    animator.SetBool("Run",true);
                    run = true;
                }
                else
                {
                    animator.SetFloat("AnimSpeed", 4.0f);
                    animator.SetTrigger("Hit");
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
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

    private void StartHit()
    {
        audio.Play();
    }

    private void EndHit()
    {
        audio.Stop();
    }
}
