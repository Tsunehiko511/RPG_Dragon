using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    // 選択状態になった時に勝手に実行される関数
    public override void OnSelect(BaseEventData eventData)
    {
        // base.OnSelect(eventData);
        Debug.Log($"{gameObject.name}が選択された");
    }

    // 非選択状態になった時に勝手に実行される関数
    public override void OnDeselect(BaseEventData eventData)
    {
        // base.OnDeselect(eventData);
        Debug.Log($"{gameObject.name}の選択が外れた");
    }
}
