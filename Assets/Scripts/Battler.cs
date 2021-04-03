using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    // HPを持っている
    public new string name;
    public int hp;

    // 攻撃ができる
    public void Attack(Battler target)
    {
        target.hp -= 3;
        Debug.Log($"{name}の攻撃:{target.name}に{3}のダメージ:残りHP{target.hp}");
    }
}
