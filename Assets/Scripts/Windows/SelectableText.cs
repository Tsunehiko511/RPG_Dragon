using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    // 関数登録用の変数
    public UnityAction<Transform> OnSelectAction = null;

    // 選択状態になった時に勝手に実行される関数
    public override void OnSelect(BaseEventData eventData)
    {
        // base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}が選択された");
        // 登録関数を実行する
        OnSelectAction.Invoke(transform);
    }

    // 非選択状態になった時に勝手に実行される関数
    public override void OnDeselect(BaseEventData eventData)
    {
        // base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name}の選択が外れた");
    }
}
