using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhaseBase
{
    public PhaseBase next;
    public abstract void Execute();
}
