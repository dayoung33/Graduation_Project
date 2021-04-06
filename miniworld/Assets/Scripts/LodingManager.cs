using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingManager : MonoBehaviour
{
    public static string nextScene;
    
    [SerializeField]
    Image progressBar;
    [SerializeField]
    Text tip;

    int RandNum = 0;

    private void Start()
    {
        RandNum = Random.Range(0, 5);
        switch(RandNum)
        {
            case 0:
                tip.text = @"Tip! 염력사용 시 마우스를 오래 누를수록 던지는 힘이 강해집니다.";
                break;
            case 1:
                tip.text = @"Tip! E키를 눌러 방어막을 사용할 수 있습니다.";
                break;
            case 2:
                tip.text = @"Tip! 빠르게 달리려면 Shift키를 눌러보세요.";
                break;
            case 3:
                tip.text = @"Tip! 새를 피하고 싶다면 빵부스러기를 사용해 보세요.";
                break;
            case 4:
                tip.text = @"Tip! M키를 이용해 미니맵을 확인할 수 있습니다.";
                break;
        }
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress < 0.9f)

            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else

            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f && timer > 2.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
