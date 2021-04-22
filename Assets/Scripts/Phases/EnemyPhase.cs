using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : PhaseBase
{
    // 技の選択/ターゲットの設定
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("EnemyPhase");
        // Enemy側のコマンド設定
        battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
        battleContext.enemy.SetTarget();
        next = new ExecutePhase();
    }
}
