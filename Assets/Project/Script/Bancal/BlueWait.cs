using System;
using UnityEngine;

public class BlueWait : BlueState
{
    public BlueWait(Blue context) : base(context)
    {
    }

    public override void Transition()
    { if (BlueContext.transform.position != BlueContext.AlphaCreator.transform.position)
        { BlueContext.CurrentState = new BlueMove(BlueContext);}
    }

    public override void SetUp() {}

    public override void Do()
    { Debug.Log("Waiting..."); }
}