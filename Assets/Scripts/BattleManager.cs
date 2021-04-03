using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // 戦闘キャラクターを作りたい
    [SerializeField] Battler player = default;
    [SerializeField] Battler enemy = default;

    enum Phase
    {
        StartPhase,
        ChooseCommandPhase, // コマンド選択
        ExcutePhase,        // 実行
        Result,
        End,
    }

    Phase phase;

    void Start()
    {
        phase = Phase.StartPhase;
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
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
                    phase = Phase.ExcutePhase;
                    break;
                case Phase.ExcutePhase:
                    player.Attack(enemy);
                    enemy.Attack(player);
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
