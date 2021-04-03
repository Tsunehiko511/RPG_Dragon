using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealCommandSO : CommandSO
{
    [SerializeField] int healPoint;

    // CommandSOのExecuteは実行せずに上書きして実行する
    public override void Execute(Battler user, Battler target)
    {
        target.hp += healPoint;
        Debug.Log($"{target.name}を{healPoint}回復:残りHP{target.hp}");
    }
}
