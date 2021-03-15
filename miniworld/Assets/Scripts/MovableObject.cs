using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public enum State {Gravity, Attack, End};
    public State curState = State.End;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform playerHand;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    private Vector3 throwAngle;
    private Vector3 OriginPos;

    private float throwPower = 1.0f;
    private float moveSpeed = 0.5f;
    private float maxThrowPower = 1.0f;
    private float GrabTime = 0.0f;

    public bool isAround = false;
 

    // Start is called before the first frame update
    void Start()
    {
        OriginPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
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
                        rigidbody.useGravity = true;
                        boxCollider.isTrigger = false;
                        throwPower *= (GrabTime * 0.3f);
                        if (throwPower >= maxThrowPower)
                            throwPower = maxThrowPower;
                        rigidbody.AddForce(throwAngle * throwPower * Time.deltaTime, ForceMode.Impulse);
                    }
                    break;
                case State.Gravity:
                    {
                        if (0.3f >= Mathf.Abs(OriginPos.y - transform.position.y))
                        {
                            GrabTime += Time.deltaTime;                         
                            rigidbody.useGravity = false;
                            boxCollider.isTrigger = true;
                            transform.position = Vector3.MoveTowards(transform.position, playerHand.position, moveSpeed * Time.deltaTime);
                        }
                    }
                    break;
                case State.End:
                    {
                        GrabTime = 0.0f;
                        rigidbody.useGravity = true;
                    }
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            curState = State.End;
    }
}
