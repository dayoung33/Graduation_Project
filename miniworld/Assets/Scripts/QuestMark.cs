using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuestMark : MonoBehaviour
{
    private UIManager UIMgr;
    public UIManager.QuestNum myQuestNum;
   

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            UIMgr = GameObject.Find("UISystem").GetComponent<UIManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (UIMgr != null)
        {
            if (other.gameObject.tag == "Player")
            {
                UIMgr.Quest(myQuestNum);
                GameObject.Destroy(gameObject, 2.0f);
            }
        }
    }
}
