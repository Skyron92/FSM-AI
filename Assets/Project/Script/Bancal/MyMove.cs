using UnityEngine;

public class MyMove : MyState
{ private Vector3 _moveTarget;
    private float rangeX, rangeZ;
    private bool HasReachedDestintaion => Vector3.Distance(_moveTarget, Context.transform.position) < 0.1f;
    public MyMove(MyFSMAI context) : base(context) { }

    public override void Transition()
    { //Transition vers Move
        if (HasReachedDestintaion)
        { Context.CurrentState = new MyMove(Context); }
        //Transition vers RunAway
        if (Context.PredatorsInRange().Count > 0)
        { Context.CurrentState = new MyAttack(Context);
        }
        //Transition vers Reproduce
        if (Context.PartnerInRange().Count > 0)
        {
            Context.CurrentState = new Reproduce(Context);
        }
        //Transition vers Attack
        if (Context.EnnemiesInRanges().Count > 0)
        { Context.CurrentState = new MyAttack(Context);
        }
    }

    public override void SetUp()
    {
        rangeX = Random.Range(1, 15);
        rangeZ = Random.Range(1, 15);
        _moveTarget = new Vector3(rangeX, Context.transform.position.y, rangeZ);
    }

    public override void Do()
    {
        Context.NavMeshAgent.SetDestination(_moveTarget);
    }
}