using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealItemSO : CommandSO
{
    [SerializeField] int healPoint;
    public override void Execute(Battler user, Battler target)
    {
        target.hp += healPoint;
        Debug.Log($"薬草の使用 {target.name}を{healPoint}回復:残りHP{target.hp}");
        user.RemoveItem(this);
    }
}
