using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowLog : MonoBehaviour
{
    Text log;

    private void Awake()
    {
        log = GetComponentInChildren<Text>();
    }

    public void ShowLog(string message)
    {
        StartCoroutine(ShowChara(message));
    }
    IEnumerator ShowChara(string message)
    {
        log.text = "";
        foreach (char c in message)
        {
            yield return new WaitForSeconds(0.02f);
            log.text += c;
        }

    }
}
