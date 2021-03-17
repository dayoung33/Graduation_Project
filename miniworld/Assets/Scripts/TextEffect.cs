using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public Text m_TypingText;
    public string message;
    public float typingSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        message = @"작은 세상에 오신 걸 환영합니다.";

        StartCoroutine(Typing(m_TypingText, message, typingSpeed));
    }

    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        message = @"WASD키를 이용해 이동해보세요.";

        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }
}
