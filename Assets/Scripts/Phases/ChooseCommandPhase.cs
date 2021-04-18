using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    // 引数で必要なデータを受け取ればいいのでは？
    public override IEnumerator Execute(BattleContext battleContext)
    {
        // 技選択をしたら次のフェーズにいく
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowBattleMenuCommand.currentID;
        if (currentID == 0)
        {
            // 0なら攻撃
            battleContext.player.selectCommand = battleContext.player.commands[0];
            battleContext.player.target = battleContext.enemy;
            battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
            battleContext.enemy.target = battleContext.player;
            next = new ExecutePhase();
        }
        else if (currentID == 1)
        {
            next = new ChooseSpellCommandPhase();
        }
        else
        {
            // それ以外なら再度ChooseCommandPhaseになる
            next = new ChooseCommandPhase();
        }


        Debug.Log("ChooseCommandPhase");
    }
}
