using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUIMgr : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip hoverFx;
    public AudioClip clickFx;

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

    public void HoverSound()
    {
        audio.PlayOneShot(hoverFx);
    }
    public void ClickSound()
    {
        audio.PlayOneShot(clickFx);
    }
}
