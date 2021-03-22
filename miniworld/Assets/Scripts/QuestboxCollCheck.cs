using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestboxCollCheck : MonoBehaviour
{
    private UIManager UIMgr;
    public UIManager.QuestNum myQuestNum;

    private void Awake()
    {
        UIMgr = GameObject.Find("UISystem").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Movable")
        {
            UIMgr.Quest(myQuestNum);
            GameObject.Destroy(gameObject, 2.0f);
        }
    }
}