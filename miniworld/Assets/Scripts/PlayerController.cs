using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private KeyCode jumpKeyCode = KeyCode.Space;
    private KeyCode shieldKeyCode = KeyCode.E;

    private Movement3D movement3D;
    private Animator animator;
    [SerializeField]
    private GameObject shieldObj;

    private bool ShieldOn = false;
    public List<GameObject> AroundObjs;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        animator = GetComponent<Animator>();
        shieldObj.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f; 
  
        animator.SetFloat("Horizontal", horizontal * offset);
        animator.SetFloat("Vertical", vertical * offset);      

        movement3D.MoveTo(new Vector3(horizontal, 0, vertical));

        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }

        if(Input.GetKeyDown(shieldKeyCode))
        {
            animator.SetTrigger("Shield");
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (AroundObjs.Count > 0)
            {
                animator.SetBool("Grabed", true);
                animator.SetFloat("AnimSpeed", 1.5f);
                foreach(var obj in AroundObjs)
                {
                    obj.GetComponent<MovableObject>().curState = MovableObject.State.Gravity;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Grabed", false);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (ShieldOn)
                return;
            animator.SetTrigger("Hit");
        }
    }

    private void ShieldEnd()
    {
        animator.ResetTrigger("Shield");
    }

    private void CreateShield()
    {
        if (!ShieldOn)
        {
            shieldObj.SetActive(true);
            ShieldOn = true;
            Invoke("ShieldOff", 5);
        }
    }

    private void ShieldOff()
    {
        ShieldOn = false;
        shieldObj.SetActive(false);
    }

    private void StartThrow()
    {
        if (AroundObjs.Count > 0)
        {
            foreach (var obj in AroundObjs)
            {
                obj.GetComponent<MovableObject>().curState = MovableObject.State.Attack;
            }
        }
    }

}
