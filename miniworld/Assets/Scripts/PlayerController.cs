using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private KeyCode jumpKeyCode = KeyCode.Space;
    private KeyCode shieldKeyCode = KeyCode.E;
    private KeyCode MiniMapKeyCode = KeyCode.M;

    private Movement3D movement3D;
    private Animator animator;
    [SerializeField]
    private GameObject shieldObj;
    [SerializeField]
    private GameObject miniMap;

    private bool ShieldOn = false;
    private bool isGrabed = false;
    public List<GameObject> AroundObjs;
    private Transform cameraArm;
    private Vector3 MoveDir;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        animator = GetComponent<Animator>();
        shieldObj.SetActive(false);
        miniMap.SetActive(false);
        cameraArm = GameObject.Find("CameraArm").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        if (horizontal !=0 || vertical != 0)
            animator.SetFloat("AnimSpeed", 1.5f);
        else
            animator.SetFloat("AnimSpeed", 1.0f);


        animator.SetFloat("Horizontal", horizontal * offset);
        animator.SetFloat("Vertical", vertical * offset);


        Vector3 camForward = new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized;
        Vector3 camRight = new Vector3(cameraArm.right.x, 0, cameraArm.right.z).normalized;

        MoveDir = camForward * vertical + camRight * horizontal * 0.3f * Time.deltaTime;
        if(vertical == 0 && horizontal != 0)
            MoveDir = camForward * 0.3f + camRight * horizontal * 0.3f * Time.deltaTime;
        if (vertical < 0)
            MoveDir = new Vector3(horizontal, 0, vertical);

        //Vector3 MoveDir = new Vector3(horizontal, 0, vertical);

        movement3D.MoveTo(MoveDir);

        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }

        if(Input.GetKeyDown(shieldKeyCode))
        {
            animator.SetTrigger("Shield");
        }

        if(Input.GetKeyDown(MiniMapKeyCode))
        {
            miniMap.SetActive(true);
        }
        if(Input.GetKeyUp(MiniMapKeyCode))
        {
            miniMap.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (AroundObjs.Count > 0)
            {
                isGrabed = true;
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
            isGrabed = false;
            animator.SetBool("Grabed", false);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (ShieldOn)
                return;
            if (collision.gameObject.GetComponent<Enemy>().curState == Enemy.State.attck)
            {
                isGrabed = false;
                animator.SetTrigger("Hit");
                if (AroundObjs.Count > 0)
                {
                    foreach (var obj in AroundObjs)
                    {
                        obj.GetComponent<MovableObject>().curState = MovableObject.State.End;
                    }
                }
            }
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
