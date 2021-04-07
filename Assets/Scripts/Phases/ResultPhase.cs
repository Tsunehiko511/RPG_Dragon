using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPhase : PhaseBase
{
    public override void Execute()
    {
        Debug.Log("ResultPhase");
        next = new EndPhase();
    }
}
