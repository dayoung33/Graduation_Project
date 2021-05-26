using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MasterSoundComtroller : MonoBehaviour
{
    public GameObject mySlider;
    private bool onSlider = false;
    public AudioMixer audioMixer;
    public Slider audioSlider;

    private void Start()
    {
        mySlider.SetActive(false);
    }

    public void masterVolmeControll()
    {
        float volume = audioSlider.value;

        if (volume == -40f) audioMixer.SetFloat("Master", -80);
        else audioMixer.SetFloat("Master", volume);
    }

    public void OnclickSetting()
    {
        if (!onSlider)
        {
            mySlider.SetActive(true);
            onSlider = true;
            
        }
        else
        {
            mySlider.SetActive(false);
            onSlider = false;
        }
    }
}
