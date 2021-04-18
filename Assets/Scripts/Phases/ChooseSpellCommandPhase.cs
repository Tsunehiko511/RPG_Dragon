using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpellCommandPhase : PhaseBase
{
    // TODO:バグ&改善
    // ・escapeでwindowを閉じたら、Menuの方を操作したいけどできない
    // ・コマンドごとのターゲットの指定
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        // 呪文一覧を表示したい！
        battleContext.windowBattleSpellCommand.gameObject.SetActive(true);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentID = battleContext.windowBattleSpellCommand.currentID;
            if (currentID == 0)
            {
                // 攻撃
                battleContext.player.selectCommand = battleContext.player.commands[0];
                battleContext.player.target = battleContext.enemy;

                battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
                battleContext.enemy.target = battleContext.player;
                next = new ExecutePhase();
            }
            else if (currentID == 1)
            {
                // 回復
                battleContext.player.selectCommand = battleContext.player.commands[1];
                battleContext.player.target = battleContext.player;

                battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
                battleContext.enemy.target = battleContext.player;
                next = new ExecutePhase();
            }
            else
            {
                // それ以外なら再度ChooseCommandPhaseになる
                next = new ChooseCommandPhase();
            }
        }
        else
        {
            next = new ChooseCommandPhase();
        }

        battleContext.windowBattleSpellCommand.gameObject.SetActive(false);
    }
}
