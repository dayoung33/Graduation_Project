using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject endingCredit;

    private void Awake()
    {
        endingCredit.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            endingCredit.SetActive(true);
            endingCredit.GetComponent<EndingCredit>().isEnd = true;
        }
    }
}
