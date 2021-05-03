using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject sister;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Movable")
        {
            sister.GetComponent<Sister>().DoorOpen();
        }
    }
}
