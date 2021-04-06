using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUIMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnclickStart()
    {
        LodingManager.LoadScene("MainStage");
    }
    public void OnclickTutorial()
    {
        LodingManager.LoadScene("Tutorial");
    }
    public void OnclickSetting()
    {
        Debug.Log("세팅");
    }
    public void OnclickQuit()
    {
        Application.Quit();
    }
}
