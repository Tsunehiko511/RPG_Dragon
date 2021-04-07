using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override void Execute()
    {
        Debug.Log("StartPhase");
        next = new ChooseCommandPhase();
    }
}
