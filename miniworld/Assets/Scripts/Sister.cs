using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : MonoBehaviour
{
    public bool isEscape = false;
    [SerializeField]
    private Transform FollowPos;
    private Animator animator;
    private Animator playerAnimator;
    public Transform shield;

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
            shield.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void DoorOpen()
    {
        isEscape = true;
        animator.SetBool("IsEscape", true);
    }
}
