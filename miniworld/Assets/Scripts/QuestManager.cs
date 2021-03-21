using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private Image backImage;
    private Text questText;
    private GameObject backObject;

    private enum quest { opening, move, grab, shield, attack, stair, finish, end};
    [SerializeField]
    private quest curQuest = quest.opening;
    private quest preQuest = quest.end;

    private float time = 0;
    private bool endFade = false;
    // Start is called before the first frame update
    void Start()
    {
        backImage = GetComponentInChildren<Image>();
        questText = GetComponentInChildren<Text>();
        backObject = GameObject.Find("TextBackground");

        questText.text = @"작은 세상에 입장하셨습니다.";
    }

    // Update is called once per frame
    void Update()
    {
        switch (curQuest)
        {
            case quest.opening:
                {
                    FadeInOut();
                    if(endFade)
                    {                      
                        curQuest = quest.move;
                        endFade = false;
                        backObject.SetActive(true);

                    }
                }
                break;
            case quest.move:
                {
                    questText.text = @"WASD 키를 이용해 이동해보세요.";
                    FadeInOut();
                }
                break;
            case quest.grab:
                { }
                break;
            case quest.shield:
                { }
                break;
            case quest.attack:
                { }
                break;
            case quest.stair:
                { }
                break;
            case quest.finish:
                { }
                break;
        }

        time += Time.deltaTime;
    }

    private void FadeInOut()
    {
        if (time < 2f)
        {
            backImage.color = new Color(0, 0, 0, time / 2);
            questText.color = new Color(1, 1, 1, time / 2);
        }
        else if (time < 3f)
        {
            backImage.color = new Color(0, 0, 0, 1 - (time - 2));
            questText.color = new Color(1, 1, 1, 1 - (time - 2));
        }
        else
        {
            time = 0;
            endFade = true;
            backObject.SetActive(false);
        }
    }


}
