using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowLog : MonoBehaviour
{
    Text log;
    // TODO：表示中は入力をまつ:連続入力の禁止
    // 書いている間は次のログをかかない！
    int lineCount; // 行数
    bool isWriting; // 書いてますよ！（この間は書かないよ！）


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
        isWriting = true;
        message += '\n'; // 改行コードを追加
        foreach (char c in message)
        {
            yield return new WaitForSeconds(0.02f);
            if (c == '\n')
            {
                lineCount++;  // 改行コードだったら行数を増やす
                if (lineCount >= 3)
                {
                    yield return MoveUpLine();
                }
            }
            // 文字の表示
            log.text += c;
        }
        isWriting = false;
    }

    IEnumerator MoveUpLine()
    {
        Debug.Log("上にあげる");
        yield return new WaitForSeconds(0.5f);
        // 一番上の行を消す
        //　・改行のところまでを削除する
        //  　・改行コードが何番目の文字なのか取得する
        //　　・取得した文字以降を残す
        int removePoint = log.text.IndexOf('\n') + 1;
        // Substring(XXX):XXXから最後までの文字列
        log.text = log.text.Substring(removePoint);
        lineCount--;
        yield return new WaitForSeconds(0.5f);
    }

    // 書いてる間は待機する
    public IEnumerator WaitWriting()
    {
        // WaitUntil() trueになったら抜ける
        yield return new WaitUntil(() => isWriting == false);
    }
}
