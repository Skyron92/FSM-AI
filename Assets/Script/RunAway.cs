using UnityEngine;
using System.Linq;


public class RunAway : MyState
{
    public RunAway(MyFSMAI context) : base(context) { }
    private float distanceWithPredator;
    private Vector3 posPredator, _runTarget;
    private float _distance;

    public override void Transition()
    {
        //Transition vers Wait
        if (Context.PredatorsInRange().Count == 0)
        { Context.CurrentState = new MyWait(Context); }
        //Transition vers Attack
        if (Context.PredatorsInRange().Count == 0 && Context.EnnemiesInRanges().Count != 0)
        { Context.CurrentState = new MyAttack(Context); }
    }

    public override void SetUp()
    { Predator FirstOrDefault = Context.PredatorsInRange().First();
        posPredator = FirstOrDefault.transform.position;
        _runTarget = -posPredator;
    }

    public override void Do()
    { Context.transform.Translate(_runTarget);
    }
}