using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        battleContext.windowBattleMenuCommand.Close();
        battleContext.windowBattleSpellCommand.Close();
        battleContext.player.selectCommand.Execute(battleContext.player, battleContext.player.target);
        battleContext.enemy.selectCommand.Execute(battleContext.enemy, battleContext.enemy.target);
        battleContext.windowLog.ShowLog("Executeフェーズ");
        // どちらかが死亡したら
        if (battleContext.player.hp <= 0 || battleContext.enemy.hp <= 0)
        {
            next = new ResultPhase();
        }
        else
        {
            battleContext.windowBattleMenuCommand.Open();
            next = new ChooseCommandPhase();
        }

        Debug.Log("ExecutePhase");
    }
}
