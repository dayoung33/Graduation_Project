using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubQuestManager : MonoBehaviour
{
    private Text subText;
    private RectTransform backTransform;
    private Image subImage;
    public GameObject backObject;
    private AudioSource audio;

    public enum eSubQuest{opening, rain, bread, spider, house, table,save,ending, end};

    private float deltaX = 100;

    public int spiderCount = 0;

    public bool clear = false;
    private bool soundInit = false;

    public eSubQuest curQuest = eSubQuest.opening;
    // Start is called before the first frame update
    void Start()
    {
        subImage = backObject.GetComponent<Image>();
        subText = backObject.GetComponentInChildren<Text>();
        backTransform = backObject.GetComponent<RectTransform>();
        backTransform.anchoredPosition = new Vector2(deltaX, 0);
        audio = GetComponent<AudioSource>();
        subText.text = @"비내리는 공원 통과하기";
    }

    public void CurQuestClear(eSubQuest num)
    {
        if (num == eSubQuest.rain)
            curQuest = eSubQuest.rain;
        
        else
            clear = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch(curQuest)
        {
            case eSubQuest.opening:
                break;
            case eSubQuest.rain:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                    }
                    else
                    {
                        QuestOut(eSubQuest.bread);
                        soundInit = false;
                    }
                    subText.text = @"비내리는 공원 통과하기";
                }
                break;
            case eSubQuest.bread:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                    }
                    else
                    {
                        QuestOut(eSubQuest.spider);
                        soundInit = false;
                    }
                    subText.text = @"새를 피해 빵 먹기";
                }
                break;
            case eSubQuest.spider:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                        subText.text = "거미 처치하기 (" + spiderCount + " / 4)";
                        if (spiderCount >= 4)
                        {
                            clear = true;
                        }
                    }
                    else
                    {
                        QuestOut(eSubQuest.house);
                        soundInit = false;               
                    }
                }
                break;           
            case eSubQuest.house:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                    }
                    else
                    {
                        QuestOut(eSubQuest.table);
                        soundInit = false;
                    }
                    subText.text = @"지도를 보고 집 찾아가기";
                }
                break;
            case eSubQuest.table:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                    }
                    else
                    { 
                        QuestOut(eSubQuest.save);
                        soundInit = false;
                    }
                    subText.text = @"식탁에 올라가기";
                }
                break;
            case eSubQuest.save:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                    }
                    else
                    {
                        QuestOut(eSubQuest.ending);
                        soundInit = false;
                    }
                    subText.text = @"케이지 안 동생 구하기";
                }
                break;
            case eSubQuest.ending:
                {
                    if (!clear)
                    {
                        QuestIn();
                        if (!soundInit)
                        {
                            audio.Play();
                            soundInit = true;
                        }
                    }
                    else
                    {
                        soundInit = false;
                    }
                    subText.text = @"빛의 기둥으로 이동하기";
                }       
                break;

            case eSubQuest.end:
                break;
        }
    }

    private void QuestIn()
    {
        if (backTransform.anchoredPosition.x >= -100)
        {
            deltaX -= 100.0f * Time.deltaTime;
            backTransform.anchoredPosition = new Vector2(deltaX, 0);
        }
        else
        {
            deltaX = -101;
            //clear = false;
        }

    }
    private void QuestOut(eSubQuest nextQuest)
    {
        if (backTransform.anchoredPosition.x <= 100)
        {
            deltaX += 100.0f * Time.deltaTime;
            backTransform.anchoredPosition = new Vector2(deltaX, 0);
        }
        else
        {
            deltaX = 101;
            if (nextQuest != eSubQuest.end)
            {
                curQuest = nextQuest;
                clear = false;
            }
            else
                Destroy(gameObject);

        }

    }
}
