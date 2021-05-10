using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private KeyCode jumpKeyCode = KeyCode.Space;
    private KeyCode shieldKeyCode = KeyCode.E;
    private KeyCode MiniMapKeyCode = KeyCode.M;
    private KeyCode ClimbKeyCode = KeyCode.G;
    private KeyCode MiniMapZoomKeyCode = KeyCode.Tab;

    private Movement3D movement3D;
    private Animator animator;
    [SerializeField]
    private GameObject shieldObj;
    [SerializeField]
    private GameObject miniMap;
    [SerializeField]
    private Transform miniMapCameraPos;

    public Transform respwnPos;
    public Transform secondRespwnPos;


    private bool MiniMapOn = false;
    public bool itsRainning = false;
    public bool underBench = false;
    public bool ShieldOn = false;
    public bool isDead = false;

    private bool isGrabed = false;
    public List<GameObject> AroundObjs;
    private Transform cameraArm;
    private Vector3 MoveDir;

    public float hitCoolTime = 0;
    public float hitMaxCoolTime = 5.0f;

    public float playerHP = 100;
    private float playerMaxHP = 100;
    public float playerMana = 100;
    private float playerMaxMana = 100;
    public float shieldCoolTime = -1.0f;
    private float shieldMaxCoolTime = 9;

    private bool isClimbing = false;
    private bool climbEnd = false;
    private bool isPushed = false;

    public SubQuestManager subQuest;

    public ParticleSystem hpParticle;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        animator = GetComponent<Animator>();
        shieldObj.SetActive(false);
        miniMap.SetActive(false);
        cameraArm = GameObject.Find("CameraArm").transform;
        //hpParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerMana < playerMaxMana)
        {
            playerMana += 10.0f * Time.deltaTime; ;
        }

        if (playerHP < playerMaxHP)
        {
            playerHP += 0.1f * Time.deltaTime; ;
        }

        if (hitCoolTime > 0.0f)
        {
            hitCoolTime -= Time.deltaTime;
        }

        if (playerHP <= 0)
            IsDead();

        if (!isDead)
        {            

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

            if (horizontal != 0 || vertical != 0)
                animator.SetFloat("AnimSpeed", 1.5f);
            else
                animator.SetFloat("AnimSpeed", 1.0f);

            if (itsRainning && !underBench && !ShieldOn)
            {
                if (playerHP > 0)
                    playerHP -= 5.0f * Time.deltaTime;
                if (!animator.GetBool("RainHit"))
                    animator.SetBool("RainHit", true);
            }
            else
            {
                animator.SetBool("RainHit", false);
            }

            Vector3 camForward = new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized;
            Vector3 camRight = new Vector3(cameraArm.right.x, 0, cameraArm.right.z).normalized;

            if (!isClimbing)
            {
                if (!climbEnd)
                {
                    animator.SetFloat("Horizontal", horizontal * offset);
                    animator.SetFloat("Vertical", vertical * offset);
                }

                MoveDir = camForward * vertical + camRight * horizontal * 0.3f * Time.deltaTime;
                if (vertical == 0 && horizontal != 0)
                    MoveDir = camForward * 0.3f + camRight * horizontal * 0.3f * Time.deltaTime;
                if (vertical < 0)
                    MoveDir = new Vector3(horizontal, 0, vertical);
            }

            else
            {
                if (!climbEnd)
                {
                    MoveDir = new Vector3(0, 0, 0);
                    movement3D.ClimbTo();
                }
                else
                {
                    movement3D.ClimbEnd();
                    MoveDir = camForward * vertical + camRight * horizontal * 0.3f * Time.deltaTime;

                }
            }

            movement3D.MoveTo(MoveDir);

            if (Input.GetKeyDown(jumpKeyCode))
            {
                movement3D.JumpTo();
            }

            if (Input.GetKeyDown(shieldKeyCode) && (shieldCoolTime <= 0.0f) && playerMana > 0.0f)
            {
                animator.SetTrigger("Shield");
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (AroundObjs.Count > 0 && playerMana > 0.0f)
                {
                    isGrabed = true;
                    animator.SetBool("Grabed", true);
                    animator.SetFloat("AnimSpeed", 1.5f);
                    foreach (var obj in AroundObjs)
                    {
                        obj.GetComponent<MovableObject>().curState = MovableObject.State.Gravity;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (isGrabed)
                {
                    isGrabed = false;
                    animator.SetBool("Grabed", false);
                }
                else
                {
                    if (AroundObjs.Count > 0)
                    {
                        foreach (var obj in AroundObjs)
                        {
                            obj.GetComponent<MovableObject>().curState = MovableObject.State.End;
                        }
                    }
                }
            }

            if (shieldCoolTime > 0.0f)
                shieldCoolTime -= Time.deltaTime;
        }

        if (Input.GetKeyUp(MiniMapKeyCode))
        {
            if (!MiniMapOn)
            {
                miniMap.SetActive(true);
                MiniMapOn = true;
            }
            else
            {
                miniMap.SetActive(false);
                MiniMapOn = false;
            }
        }

        if (MiniMapOn)
        {

            if (Input.GetKeyDown(MiniMapZoomKeyCode))
            {
                if (SceneManager.GetActiveScene().name == "MainStage")
                    miniMapCameraPos.position = new Vector3(transform.position.x, 80, transform.position.z - 20);
                else if (SceneManager.GetActiveScene().name == "Tutorial")
                    miniMapCameraPos.position = new Vector3(transform.position.x, 20, transform.position.z - 0);
            }
            if (Input.GetKeyUp(MiniMapZoomKeyCode))
            {
                if (SceneManager.GetActiveScene().name == "MainStage")
                    miniMapCameraPos.position = new Vector3(4.2f, 182, -44);
                else if (SceneManager.GetActiveScene().name == "Tutorial")
                    miniMapCameraPos.position = new Vector3(1.2f, 40, 35);
            }

        }
    }

    private void LateUpdate()
    {
        if (playerMana <= 0.0f)
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
            if (collision.gameObject.GetComponent<Enemy>().curState == Enemy.State.attck && hitCoolTime <= 0.0f)
            {
                hitCoolTime = hitMaxCoolTime;
                isGrabed = false;
                animator.SetTrigger("Hit");
                if (playerHP > 0)
                    playerHP -= 10;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "vecuum")
        {
            hitCoolTime = hitMaxCoolTime;
            isGrabed = false;
            animator.SetTrigger("Hit");
            if(playerHP > 0)
                playerHP -= 10;
            if (AroundObjs.Count > 0)
            {
                foreach (var obj in AroundObjs)
                {
                    obj.GetComponent<MovableObject>().curState = MovableObject.State.End;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rain")
        {
            itsRainning = true;
        }
        if (other.gameObject.tag == "NotRain")
        {
            underBench = true;
        }
        if (other.gameObject.tag == "ClimbingEnd")
        {
            animator.SetTrigger("ClimbingEnd");
            climbEnd = true;
        }
        if (other.gameObject.tag == "MonsterWeapon")
        {
            hitCoolTime = hitMaxCoolTime;
            isGrabed = false;
            animator.SetTrigger("Hit");
            if (playerHP > 0)
                playerHP -= 10;
            if (AroundObjs.Count > 0)
            {
                foreach (var obj in AroundObjs)
                {
                    obj.GetComponent<MovableObject>().curState = MovableObject.State.End;
                }
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ClimbingStart")
        {
            if (Input.GetKeyDown(ClimbKeyCode))
            {
                animator.SetTrigger("ClimbingStart");
                isClimbing = true;
                movement3D.isClimbing = true;
            }
        }
        if (other.gameObject.tag == "food")
        {
            if (!isPushed && Input.GetKeyDown(ClimbKeyCode))
            {
                if (subQuest.curQuest == SubQuestManager.eSubQuest.bread)
                    subQuest.CurQuestClear(SubQuestManager.eSubQuest.bread);
                isPushed = true;
                animator.SetTrigger("isPicked");
                playerHP += 10;
                if (playerHP > 100)
                    playerHP = 100;
                hpParticle.Play();
            }
            if(Input.GetKeyUp(ClimbKeyCode))
            {
                isPushed = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Rain")
        {
            itsRainning = false;
        }
        if (other.gameObject.tag == "NotRain")
        {
            underBench = false;
        }
        if (other.gameObject.tag == "ClimbingEnd")
        {
            subQuest.CurQuestClear(SubQuestManager.eSubQuest.table);
            climbEnd = false;
            isClimbing = false;
            movement3D.isClimbing = false;
        }

    }

    private void IsDead()
    {
        isDead = true;
        animator.SetBool("Death", true);
        hitCoolTime = hitMaxCoolTime;
    }

    //public void Resurrection()
    //{
    //    animator.SetBool("Death", false);
    //    playerHP = 100;
    //    playerMana = 100;
    //    isDead = false;
    //}


    private void ShieldEnd()
    {
        animator.ResetTrigger("Shield");
    }

    private void CreateShield()
    {
        if (!ShieldOn)
        {
            shieldCoolTime = shieldMaxCoolTime;
            shieldObj.SetActive(true);
            ShieldOn = true;
            Invoke("ShieldOff", 7);
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

    private void EndPickUp()
    {
        hpParticle.Stop();
    }

    public void Respawn()
    {
        animator.SetBool("Death", false);
        playerHP = 100;
        playerMana = 100;
        isDead = false;
        if(subQuest.curQuest == SubQuestManager.eSubQuest.rain)
            transform.position = respwnPos.position;
        if (subQuest.curQuest == SubQuestManager.eSubQuest.spider)
            transform.position = secondRespwnPos.position;
    }

}
