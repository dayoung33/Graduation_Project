using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogoManger : MonoBehaviour
{
    float totalTimer = 0.0f;
    public Text LogoText;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        totalTimer += Time.deltaTime;
        if (LogoText.fontSize >= 30)
            LogoText.fontSize -= 1;

        else
        {
            timer += Time.deltaTime;
            if(timer <0.5f)
                LogoText.color = new Color(0.0f, 0.0f, 0.0f, 1-timer);
            else
            {
                LogoText.color = new Color(0.0f, 0.0f, 0.0f, timer);
                if (timer > 1f)
                    timer = 0;
            }
        }
        if (totalTimer >= 5.0f)
            LodingManager.LoadScene("MainMenu");
    }
}
