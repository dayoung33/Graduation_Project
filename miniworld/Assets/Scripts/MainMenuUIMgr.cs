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
        SceneManager.LoadScene("Demo");
    }
    public void OnclickQuit()
    {
        Application.Quit();
    }
}
