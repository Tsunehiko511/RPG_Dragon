using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    // *技の実装*
    // 技は独立したクラスで管理する
    // ScriptableObjectで管理する
    // 技の種類を増やすのは「継承」を使う


    // HPを持っている
    public new string name;
    public int hp;

    // 実行するコマンド
    public CommandSO selectCommand;
    public Battler target;
    public Battler enemy;

    // 持ってる技
    public List<CommandSO> commands = new List<CommandSO>();
    // これをwindowに渡す(string形式)
    // windowは受け取って表示する

    public List<CommandSO> inventory = new List<CommandSO>();
    public string[] GetStringOfItem()
    {
        return GetStringOf(inventory);
    }

    public string[] GetStringOfCommands()
    {
        return GetStringOf(commands);
    }

    string[] GetStringOf(List<CommandSO> commands)
    {
        List<string> list = new List<string>();
        foreach (CommandSO command in commands)
        {
            list.Add(command.name);
        }
        return list.ToArray();
    }

    public void RemoveItem(CommandSO item)
    {
        inventory.Remove(item);
    }



    public void SetTarget()
    {
        if(selectCommand.targetType == CommandSO.TargetType.Self)
        {
            target = this;
        }
        else if (selectCommand.targetType == CommandSO.TargetType.Enemy)
        {
            target = enemy;
        }
    }
}
