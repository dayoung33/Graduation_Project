using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public enum State {Gravity, Attack, End};
    public State curState = State.End;

    private Transform playerTransform;
    private Transform playerHand;

    private Rigidbody myrigidbody;
    private BoxCollider boxCollider;

    private Vector3 throwAngle;
    private Vector3 OriginPos;

    PlayerController playercontroller;
    private float throwPower = 1.0f;
    private float moveSpeed = 1.0f;
    private float maxThrowPower = 1.0f;
    public float GrabTime = 0.0f;

    public bool isAround = false;

    private AudioSource audio;
 

    // Start is called before the first frame update
    void Start()
    {
        OriginPos = transform.position;
        myrigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        playerTransform = GameObject.Find("Female_01_V01").transform;
        playercontroller = GameObject.Find("Female_01_V01").GetComponent<PlayerController>();
        playerHand = GameObject.Find("GrabObject").transform;
        audio = GetComponent<AudioSource>();
}

// Update is called once per frame
void Update()
    {
        if (isAround)
        {
            switch (curState)
            {
                case State.Attack:
                    {
                        throwAngle = playerTransform.forward * 10.0f;
                        throwAngle.y = 10.0f;
                        myrigidbody.useGravity = true;
                        boxCollider.isTrigger = false;
                        throwPower *= (GrabTime * 0.4f);
                        if (throwPower >= maxThrowPower)
                            throwPower = maxThrowPower;
                        myrigidbody.AddForce(throwAngle * throwPower * Time.deltaTime, ForceMode.Impulse);
                    }
                    break;
                case State.Gravity:
                    {
                        if (0.3f >= Mathf.Abs(OriginPos.y - transform.position.y))
                        {
                            GrabTime += Time.deltaTime;
                            if (GrabTime > 4.0f)
                                GrabTime = 4.0f;
                            playercontroller.playerMana -= (GrabTime * 0.03f);
                            if (playercontroller.playerMana < -10.0f)
                                playercontroller.playerMana = -10.0f;
                            myrigidbody.useGravity = false;
                            boxCollider.isTrigger = true;
                            transform.position = Vector3.MoveTowards(transform.position, playerHand.position, moveSpeed * Time.deltaTime);
                        }
                    }
                    break;
                case State.End:
                    {
                        GrabTime = 0.0f;
                        myrigidbody.useGravity = true;
                        boxCollider.isTrigger = false;
                    }
                    break;
            }
        }
        else
        {
            curState = State.End;
            GrabTime = 0.0f;
            boxCollider.isTrigger = false;
            myrigidbody.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(curState!= State.End)
                audio.Play();
            curState = State.End;
           
        }
    }
}
