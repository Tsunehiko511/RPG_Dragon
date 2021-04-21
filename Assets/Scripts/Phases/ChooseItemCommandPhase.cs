using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItemCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        // アイテム一覧の表示
        battleContext.windowBattleItemCommand.CreateSelectableText(battleContext.player.GetStringOfItem());
        yield return null;
        battleContext.windowBattleItemCommand.Open();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 選択したアイテム
            int currentID = battleContext.windowBattleItemCommand.currentID;
            // コマンドの設定
            battleContext.player.selectCommand = battleContext.player.inventory[currentID];
            //ターゲットの設定
            battleContext.player.SetTarget();
            // Enemy側のコマンド設定
            battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
            battleContext.enemy.SetTarget();
            next = new ExecutePhase();
        }
        else
        {
            battleContext.windowBattleItemCommand.Select();
            next = new ChooseCommandPhase();
        }

        battleContext.windowBattleItemCommand.gameObject.SetActive(false);
    }
}
