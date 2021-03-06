using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private Image backImage;
    private RectTransform backTransform;
    private Text questText;
    private GameObject backObject;

    public enum eQuest { opening, walk, run, map, grab, fstQuest, StartfstQuest, shield, attack, finish, end};
    [SerializeField]
    public eQuest curQuest = eQuest.opening;

    private float time = 0;
    private bool endFade = false;
    // Start is called before the first frame update
    void Start()
    {
        backObject = GameObject.Find("TextBackground");
        backImage = backObject.GetComponentInChildren<Image>();
        questText = GetComponentInChildren<Text>();
        backTransform = backObject.GetComponentInChildren<RectTransform>();

        questText.text = @"작은 세상에 입장하셨습니다.";
    }


    // Update is called once per frame
    void Update()
    {
        switch (curQuest)
        {
            case eQuest.opening:
                {
                    FadeInOut();
                    if(endFade)
                    {                      
                        curQuest = eQuest.walk;
                        endFade = false;
                        backObject.SetActive(true);

                    }
                }
                break;
            case eQuest.walk:
                {
                    backTransform.sizeDelta = new Vector2(500, 60);
                    questText.text = @"WASD 키로 이동해 느낌표를 찾아가세요.";
                    FadeInOut();
                    if (endFade)
                    {
                        curQuest = eQuest.run;
                        endFade = false;
                        backObject.SetActive(true);

                    }
                }
                break;
            case eQuest.run:
                {
                    backTransform.sizeDelta = new Vector2(420, 60);
                    questText.text = @"Shift키를 누르면 달릴 수 있습니다.";
                    FadeInOut();
                }
                break;
            case eQuest.map:
                {
                    backTransform.sizeDelta = new Vector2(440, 60);
                    questText.text = @"M 키를 누르면 지도를 볼 수 있습니다.";
                    FadeInOut();
                }
                break;
            case eQuest.grab:
                {
                    backTransform.sizeDelta = new Vector2(600, 60);
                    questText.text = @"마우스 좌클릭으로 가까이 있는 물체를 움직일 수 있습니다.";
                    FadeInOut();
                }
                break;
            case eQuest.fstQuest:
                {
                    backTransform.sizeDelta = new Vector2(500, 60);
                    questText.text = @"좋아요 앞의 프레임 안에 상자를 넣어보세요.";
                    FadeInOut();
                }
                break;
            case eQuest.StartfstQuest:
                {
                    backTransform.sizeDelta = new Vector2(700, 60);
                    questText.text = @"잘했어요. 이제 공격을 배우러 가볼까요. 새로운 느낌표 찾아가세요.";
                    FadeInOut();
                }
                break;
            case eQuest.shield:
                {
                    backTransform.sizeDelta = new Vector2(420, 60);
                    questText.text = @"E 키를 누르면 방어막이 생성됩니다.";
                    FadeInOut();
                }
                break;
            case eQuest.attack:
                {
                    backTransform.sizeDelta = new Vector2(700, 60);
                    questText.text = @"클릭하는 시간동안 던지는 힘이 세집니다. 스킬을 이용해 거미를 죽이세요";
                    FadeInOut();
                }
                break;
            case eQuest.finish:
                {
                    backTransform.sizeDelta = new Vector2(600, 60);
                    questText.text = @"대단해요! 이제 튜터리얼 마지막 단계인 빛의 기둥에 도착하세요.";
                    FadeInOut();
                }
                break;
        }

        time += Time.deltaTime;
    }

    private void FadeInOut()
    {
        if (time < 1f)
        {
            backImage.color = new Color(0, 0, 0, time);
            questText.color = new Color(1, 1, 1, time);
        }
        else if(time < 4f)
        {
            backImage.color = new Color(0, 0, 0, 1);
            questText.color = new Color(1, 1, 1, 1);
        }
        else if (time < 5f)
        {
            backImage.color = new Color(0, 0, 0, 1 - (time - 4));
            questText.color = new Color(1, 1, 1, 1 - (time - 4));
        }
        else
        {
            time = 0;
            endFade = true;
            backObject.SetActive(false);
        }
    }


}
