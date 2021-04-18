using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowBattleMenuCommand : MonoBehaviour
{
    // SelectableTextが選択されたら、カーソルの移動をする
    [SerializeField] Transform arrow = default;

    // SelectableTextが選択されたら
    // SelectableTextにMoveArrowToの関数の登録を行う
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();

    // 選択中の子要素のID
    public int currentID; 

    void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts)
        {
            selectableText.OnSelectAction = MoveArrowTo;
        }

        // 最初から攻撃を選択状態にしたい
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    // カーソルの移動をする:親を変更する
    public void MoveArrowTo(Transform parent)
    {
        arrow.SetParent(parent);
        // GetSiblingIndexとは、親からみて何番目の子要素か？
        currentID = parent.GetSiblingIndex();
        Debug.Log($"カーソル移動:currentID{currentID}");
    }

    // 呪文ウィンドウを閉じたら、元々のWindowに選択状態を戻す
    public void Select()
    {
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    // ウィンドウを閉じる
    public void Open()
    {
        currentID = 0;
        gameObject.SetActive(true);
        SetMoveArrowFunction();
    }

    // ウィンドウを閉じる
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
