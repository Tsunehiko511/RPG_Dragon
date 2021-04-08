using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpellCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        // 呪文一覧を表示したい！
        battleContext.windowBattleSpellCommand.gameObject.SetActive(true);

        // TODO:呪文の効果を発動！
    }
}
