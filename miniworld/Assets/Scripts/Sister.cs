using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : MonoBehaviour
{
    private bool isEscape = false;
    [SerializeField]
    private Transform FollowPos;
    private Animator animator;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GameObject.Find("Female_01_V01").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEscape)
        {
            transform.rotation = GameObject.Find("Female_01_V01").transform.rotation;
            transform.position = FollowPos.position;
            animator.SetFloat("Horizontal", playerAnimator.GetFloat("Horizontal"));
            animator.SetFloat("Vertical", playerAnimator.GetFloat("Vertical"));
        }
    }

    public void DoorOpen()
    {
        isEscape = true;
        animator.SetBool("IsEscape", true);
    }
}
