using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunQuestCollboxx : MonoBehaviour
{
    private SubQuestManager subQuestMgr;
    public SubQuestManager.eSubQuest myQuestNum;

    private void Awake()
    {
        subQuestMgr = GameObject.Find("QuestManager").GetComponent<SubQuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            subQuestMgr.CurQuestClear(myQuestNum);
            GameObject.Destroy(gameObject, 2.0f);
        }
    }
}
