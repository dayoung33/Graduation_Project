using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainQuestmanager : MonoBehaviour
{
    private Image backImage;
    private RectTransform backTransform;
    private Text questText;
    private GameObject backObject;

    public enum eQuest { opening, mainquest, end };
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

        questText.text = @"[메인 퀘스트가 도착했습니다.]";
    }

    // Update is called once per frame
    void Update()
    {
        switch (curQuest)
        {
            case eQuest.opening:
                {
                    FadeInOut();
                    if (endFade)
                    {
                        curQuest = eQuest.mainquest;
                        endFade = false;
                        backObject.SetActive(true);

                    }
                }
                break;
            case eQuest.mainquest:
                {
                    backTransform.sizeDelta = new Vector2(300, 60);
                    questText.text = @"[공주를 구출하세요.]";
                    FadeInOut();
                    if (endFade)
                    {
                        curQuest = eQuest.end;
                        endFade = false;
                        backObject.SetActive(true);

                    }
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
        else if (time < 4f)
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