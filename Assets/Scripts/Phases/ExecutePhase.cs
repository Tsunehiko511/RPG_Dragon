using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public override void Execute()
    {
        Debug.Log("ExecutePhase");
        next = new ResultPhase();
    }
}
