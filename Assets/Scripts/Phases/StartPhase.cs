using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("StartPhase");
        battleContext.SetEnemy();
        battleContext.windowBattleMenuCommand.Open();
        battleContext.windowLog.ShowLog(battleContext.enemy.name+"があらわれた!");
        next = new ChooseCommandPhase();
    }
}
