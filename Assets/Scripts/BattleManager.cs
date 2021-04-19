using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // 今日やりたいこと
    // ・各フェーズに引数で渡すものをまとめる => 構造体
    // 構造体とは？ => ほぼクラス(劣化版？)

    // Battleで必要な変数をまとめたもの
    [SerializeField] BattleContext battleContext;
    PhaseBase phaseState;

    void Start()
    {
        phaseState = new StartPhase();
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (!(phaseState is EndPhase))
        {
            // フェーズの実行
            yield return phaseState.Execute(battleContext);
            // 次のフェーズに以降
            phaseState = phaseState.next;
        }
        // EndPhaseの実行
        yield return phaseState.Execute(battleContext);


        yield break; // ここより下は実行しない
    }
}

// バトルに使う変数をまとめる:構造体(変数と関数をまとめたもの)
[System.Serializable]
public struct BattleContext
{
    // 戦闘キャラクターを作りたい
    public Battler player;
    public Battler enemy;

    // Window
    public WindowBattleMenuCommand windowBattleMenuCommand;
    public WindowBattleMenuCommand windowBattleSpellCommand;
    public void SetEnemy()
    {
        player.enemy = enemy;
        enemy.enemy = player;
    }
}