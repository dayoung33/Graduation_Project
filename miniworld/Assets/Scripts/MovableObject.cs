using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public enum State {Gravity, Attack, End};
    [SerializeField]
    public State curState = State.End;
    [SerializeField]
    private Transform playerHand;
    private Rigidbody rigidbody;
    [SerializeField]
    private Transform playerTransform;
    Vector3 OriginPos;
    private float moveSpeed = 0.5f;
    public bool isAround = false;
    private Vector3 throwAngle;
    private float throwPower = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        OriginPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
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
                        throwAngle = playerTransform.forward * 0.3f;
                        throwAngle.y = 1.0f;
                        rigidbody.useGravity = true;
                        rigidbody.AddForce(throwAngle * throwPower, ForceMode.Impulse);
                    }
                    break;
                case State.Gravity:
                    {
                        if (0.3f >= Mathf.Abs(OriginPos.y - transform.position.y))
                        {
                            rigidbody.useGravity = false;
                            transform.position = Vector3.MoveTowards(transform.position, playerHand.position, moveSpeed * Time.deltaTime);
                        }
                    }
                    break;
                case State.End:
                    {
                        rigidbody.useGravity = true;
                    }
                    break;
            }
        }
    }

}
