using UnityEngine;

public class MyWait : MyState
{
    public MyWait(MyFSMAI context) : base(context) { }

    public override void Transition()
    { //Transition vers Move
        if (Input.GetButtonDown("Fire2"))
        { Context.CurrentState = new MyMove(Context);
        }
        //Transition vers Attack
        if (Context.EnnemiesInRanges().Count > 0)
        { Context.CurrentState = new MyAttack(Context);
        }
        //Transition vers RunAway
        if (Context.PredatorsInRange().Count > 0)
        {
            Context.CurrentState = new MyAttack(Context);
        }
    }

    public override void SetUp() {}

    public override void Do()
    {
    }
}