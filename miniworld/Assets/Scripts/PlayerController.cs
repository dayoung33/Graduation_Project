using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private KeyCode jumpKeyCode = KeyCode.Space;
    private KeyCode shieldKeyCode = KeyCode.E;

    private Movement3D movement3D;
    private Animator animator;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        animator = GetComponent<Animator>();
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

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

    }

    private void ShieldEnd()
    {
        animator.ResetTrigger("Shield");
    }
}
