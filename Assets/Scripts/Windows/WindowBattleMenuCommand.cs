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
}
