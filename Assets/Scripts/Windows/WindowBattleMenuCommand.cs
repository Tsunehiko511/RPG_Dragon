using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBattleMenuCommand : MonoBehaviour
{
    // SelectableTextが選択されたら、カーソルの移動をする
    [SerializeField] Transform arrow = default;

    // SelectableTextが選択されたら
    // SelectableTextにMoveArrowToの関数の登録を行う
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();

    private void Start()
    {
        // テスト用
        SetMoveArrowFunction();
    }

    void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts)
        {
            selectableText.OnSelectAction = MoveArrowTo;
        }
    }

    // カーソルの移動をする:親を変更する
    public void MoveArrowTo(Transform parent)
    {
        Debug.Log("カーソル移動");
        arrow.SetParent(parent);
    }
}
