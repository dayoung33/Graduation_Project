using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCredit : MonoBehaviour
{
    public Image backImage;
    public RectTransform textTransform;
    public AudioSource playersound;
    private float time = 0;
    public bool isEnd = false;
    private float ypos = -700;
    private bool isinit = false;
    public GameObject quitbtn;

    private void Start()
    {
        backImage.color = new Color(1, 1, 1, 0);
        quitbtn.SetActive(false);
    }

    void Update()
    {
        if(isEnd)
        {
            time += Time.deltaTime;
            if (time <= 1f)
            {
                backImage.color = new Color(1, 1, 1, time);               
            }
            else
            {
                if (!isinit)
                {
                    playersound.mute = true;
                    isinit = true;
                }
                backImage.color = new Color(1, 1, 1, 1);
                if (ypos <= 0)
                {
                    ypos += 100 * Time.deltaTime;
                    textTransform.anchoredPosition3D = new Vector3(0, ypos, 0);
                }
                else
                {
                    isEnd = false;
                    quitbtn.SetActive(true);

                }
            }
        }
    }

    public void OnclickQuit()
    {
        Application.Quit();
    }

}
