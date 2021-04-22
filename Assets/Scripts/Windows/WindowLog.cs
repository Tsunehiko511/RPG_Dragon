using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowLog : MonoBehaviour
{
    Text log;
    // TODO:ログが3行だったら上にあげる
    // ・ログを1行ずつ表示する:OK
    // ・表示する際に3行すでに表示されていれば
    //  　・一番上のログを削除する
    //　　・下に新規を1行表示する

    // 次回：表示中は入力をまつ

    int lineCount; // 行数

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
        // log.text = "";
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
}
