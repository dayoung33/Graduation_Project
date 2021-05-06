using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Vecuum : MonoBehaviour
{
    public Transform[] target = new Transform[4];
    private Transform curTarget;
    NavMeshAgent nav;
    private int targetnum = 0;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        curTarget = target[targetnum];
        nav.SetDestination(curTarget.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Spot")
        {
            if (targetnum == 0)
                targetnum = 3;
            else
                targetnum -= 1;


            curTarget = target[targetnum];
            nav.SetDestination(curTarget.position);
        }
    }
}
