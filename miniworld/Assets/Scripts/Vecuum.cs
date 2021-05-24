using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Vecuum : MonoBehaviour
{
    public Transform[] target = new Transform[4];
    private Transform curTarget;
    NavMeshAgent nav;
    [SerializeField]
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
            int randomNum = Random.Range(0, 4);
            if (targetnum == randomNum)
            {
                if (targetnum == 0)
                    randomNum += 1;
                else
                    randomNum -= 1;
            }
            
            targetnum = randomNum;
            curTarget = target[targetnum];
            nav.SetDestination(curTarget.position);
        }
    }
}
