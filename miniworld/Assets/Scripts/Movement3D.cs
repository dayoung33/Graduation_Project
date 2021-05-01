﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.3f;
    [SerializeField]
    private float runSpeed = 0.6f;
    [SerializeField]
    private float jumpForce = 2.5f;
    private float gravity = -9.8f;
    private Vector3 moveDirection;
    private CharacterController charcterController;
    private Animator animator;
    [SerializeField]
    private Transform UpPos;

    public bool isClimbing = false;
    

    // Start is called before the first frame update
    private void Awake()
    {
       charcterController = GetComponent<CharacterController>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(charcterController.isGrounded ==false && !isClimbing)
        {
            moveDirection.y += gravity * Time.deltaTime;
            animator.ResetTrigger("Jump");
        }

        float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));

        if(moveDirection.x!=0&&moveDirection.z!=0)
            transform.forward = new Vector3(moveDirection.x, transform.forward.y, moveDirection.z).normalized;
        charcterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 nomalizeDirection = direction.normalized;
        moveDirection = new Vector3(nomalizeDirection.x, moveDirection.y, nomalizeDirection.z);
    }

    public void ClimbTo()
    {
        moveDirection.y = 0.3f;
    }

    public void ClimbEnd()
    {
        moveDirection.y = 0.0f;
    }


    public void JumpTo()
    {
        if(charcterController.isGrounded==true)
        {
            moveDirection.y = jumpForce;
            animator.SetTrigger("Jump");
        }
    }

    public void ArrivalEvent()
    {
        transform.position = UpPos.position;
    }

}
