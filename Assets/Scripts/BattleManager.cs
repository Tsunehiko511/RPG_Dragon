using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // 戦闘キャラクターを作りたい
    [SerializeField] Battler player = default;
    [SerializeField] Battler enemy = default;

    // Window
    [SerializeField] WindowBattleMenuCommand windowBattleMenuCommand = default;

    // 本日の内容：ステートパターンの導入
    // 何がよくなる？
    // ・switch文がなくなる
    // ・フェーズが増えてもBattleManager.csを変更しなくていい

    // フェーズの多様化

    PhaseBase phaseState;

    enum Phase
    {
        StartPhase,
        ChooseCommandPhase, // コマンド選択
        ExecutePhase,        // 実行
        Result,
        End,
    }

    Phase phase;

    void Start()
    {
        // phase = Phase.StartPhase;
        phaseState = new StartPhase();
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (!(phaseState is EndPhase))
        {
            // フェーズの実行
            phaseState.Execute();
            // 次のフェーズに以降
            phaseState = phaseState.next;
        }
        // EndPhaseの実行
        phaseState.Execute();


        yield break; // ここより下は実行しない

        while (phase != Phase.End)
        {
            yield return null;
            Debug.Log(phase);
            switch (phase)
            {
                case Phase.StartPhase:
                    //
                    phase = Phase.ChooseCommandPhase;
                    break;
                case Phase.ChooseCommandPhase:
                    // 技選択をしたら次のフェーズにいく
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    int currentID = windowBattleMenuCommand.currentID;
                    if (currentID == 0)
                    {
                        // 0なら攻撃
                        player.selectCommand = player.commands[0];
                        player.target = enemy;
                        enemy.selectCommand = enemy.commands[0];
                        enemy.target = player;
                        phase = Phase.ExecutePhase;
                    }
                    else
                    {
                        // それ以外なら再度ChooseCommandPhaseになる
                        phase = Phase.ChooseCommandPhase;
                    }
                    break;
                case Phase.ExecutePhase:
                    player.selectCommand.Execute(player,player.target);
                    enemy.selectCommand.Execute(enemy,enemy.target);
                    // どちらかが死亡したら
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                    }
                    else
                    {
                        phase = Phase.ChooseCommandPhase;
                    }
                    break;
                case Phase.Result:
                    // 
                    phase = Phase.End;
                    break;
                case Phase.End:
                    // 
                    break;
            }
        }
    }
}
