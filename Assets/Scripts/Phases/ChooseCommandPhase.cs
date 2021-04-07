using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public override void Execute()
    {
        Debug.Log("ChooseCommandPhase");
        next = new ExecutePhase();
    }
}
