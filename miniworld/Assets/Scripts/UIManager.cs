﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum QuestNum { Grab,collBox,boxQuest,Shield, Attack,Finish};
    public GameObject textObject;

    public void Quest(QuestNum ID)
    {
        switch(ID)
        {
            case QuestNum.Grab:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.quest.grab;
                }
                break;
            case QuestNum.collBox:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.quest.fstQuest;
                }
                break;
            case QuestNum.boxQuest:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.quest.StartfstQuest;
                }
                break;
            case QuestNum.Shield:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.quest.shield;
                }
                break;
            case QuestNum.Attack:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.quest.attack;
                }
                break;
            case QuestNum.Finish:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.quest.finish;
                }
                break;
        }
    }
}