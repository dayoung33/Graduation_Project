using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum QuestNum { Grab,collBox,boxQuest,Shield, Attack,Finish};
    public GameObject textObject;
    public GameObject CheatBoxObject;
    public GameObject LightSylinder;
    private AudioSource audio;

    private void Awake()
    {
        LightSylinder.SetActive(false);
        audio = GetComponent<AudioSource>();
        CheatBoxObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F4))
            CheatBoxObject.SetActive(true);
    }

    public void Quest(QuestNum ID)
    {
        audio.Play();
        switch(ID)
        {
            case QuestNum.Grab:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.eQuest.grab;
                }
                break;
            case QuestNum.collBox:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.eQuest.fstQuest;
                }
                break;
            case QuestNum.boxQuest:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.eQuest.StartfstQuest;
                }
                break;
            case QuestNum.Shield:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.eQuest.shield;
                }
                break;
            case QuestNum.Attack:
                {
                    textObject.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.eQuest.attack;
                }
                break;
            case QuestNum.Finish:
                {
                    textObject.SetActive(true);
                    LightSylinder.SetActive(true);
                    textObject.GetComponentInParent<QuestManager>().curQuest = QuestManager.eQuest.finish;
                }
                break;
        }
    }
}
