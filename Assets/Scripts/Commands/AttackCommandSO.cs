using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int at;

    // CommandSOのExecuteは実行せずに上書きして実行する
    public override void Execute(Battler user, Battler target)
    {
        target.hp -= at;
        Debug.Log($"{target.name}に{at}のダメージ:残りHP{target.hp}");
    }
}
