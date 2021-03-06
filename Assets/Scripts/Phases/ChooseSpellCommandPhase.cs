using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpellCommandPhase : PhaseBase
{
    // TODO:バグ&改善
    // ・コマンドごとのターゲットの指定
    public override IEnumerator Execute(BattleContext battleContext)
    {
        // 呪文一覧を表示したい！
        battleContext.windowBattleSpellCommand.CreateSelectableText(battleContext.player.GetStringOfCommands());
        yield return null; 
        battleContext.windowBattleSpellCommand.Open();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 選択したコマンド
            int currentID = battleContext.windowBattleSpellCommand.currentID;
            // コマンドの設定
            battleContext.player.selectCommand = battleContext.player.commands[currentID];
            //ターゲットの設定
            battleContext.player.SetTarget();
            next = new EnemyPhase();
        }
        else
        {
            battleContext.windowBattleMenuCommand.Select();
            next = new ChooseCommandPhase();
        }

        battleContext.windowBattleSpellCommand.gameObject.SetActive(false);
    }
}
