using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArea : MonoBehaviour
{
    PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Movable")
        {
            //playerController.hasAroundObj = true;
            MovableObject MoveSc = other.gameObject.GetComponent<MovableObject>();
            MoveSc.isAround = true;
            playerController.AroundObjs.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Movable")
        {
            MovableObject MoveSc = other.gameObject.GetComponent<MovableObject>();
            MoveSc.isAround = false;
            playerController.AroundObjs.Remove(other.gameObject);
        }
    }

}
