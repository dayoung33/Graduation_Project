using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.2f;
    [SerializeField]
    private float runSpeed = 0.4f;
    [SerializeField]
    private float jumpForce = 2.5f;
    private float rotateSpeed = 1.0f;
    private float gravity = -9.8f;
    private Vector3 moveDirection;
    private CharacterController charcterController;
    private Animator animator;

    //[SerializeField]
    //private Transform cameraTransform;


    // Start is called before the first frame update
    private void Awake()
    {
       charcterController = GetComponent<CharacterController>();
       animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        if(charcterController.isGrounded ==false)
        {
            moveDirection.y += gravity * Time.deltaTime;
            animator.ResetTrigger("Jump");
        }

        float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));

        Vector3 nomalizeDirection = moveDirection.normalized;
        transform.forward = new Vector3(nomalizeDirection.x, 0, nomalizeDirection.z);
        charcterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 nomalizeDirection = direction.normalized;
        moveDirection = new Vector3(nomalizeDirection.x, moveDirection.y, nomalizeDirection.z);
    }

    public void JumpTo()
    {
        if(charcterController.isGrounded==true)
        {
            moveDirection.y = jumpForce;
            animator.SetTrigger("Jump");
        }
    }
}
