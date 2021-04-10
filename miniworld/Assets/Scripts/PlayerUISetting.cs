using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUISetting : MonoBehaviour
{
    PlayerController playercontroller;

    private float playerHP;
    private float playerMana;
    private float shieldCooltime;

    public Image manaImage;
    public Image HPImaage;
    public Text timeText;
    public Image Blood;



    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontroller.shieldCoolTime > 8.0f) timeText.text = @"9";
        else if (playercontroller.shieldCoolTime > 7.0f) timeText.text = @"8";
        else if (playercontroller.shieldCoolTime > 6.0f) timeText.text = @"7";
        else if (playercontroller.shieldCoolTime > 5.0f) timeText.text = @"6";
        else if (playercontroller.shieldCoolTime > 4.0f) timeText.text = @"5";
        else if (playercontroller.shieldCoolTime > 3.0f) timeText.text = @"4";
        else if (playercontroller.shieldCoolTime > 2.0f) timeText.text = @"3";
        else if (playercontroller.shieldCoolTime > 1.0f) timeText.text = @"2";
        else if (playercontroller.shieldCoolTime > 0.0f) timeText.text = @"1";
        else timeText.text = @" ";


        manaImage.fillAmount = playercontroller.playerMana * 0.01f;
        HPImaage.fillAmount = playercontroller.playerHP * 0.01f;

       // if(playercontroller.hitCoolTime >0.0f)
       // {
            Blood.color = new Color(1, 1, 1, (playercontroller.hitCoolTime / playercontroller.hitMaxCoolTime));
       // }

    }
}
