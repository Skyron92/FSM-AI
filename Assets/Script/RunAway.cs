using UnityEngine;
using System.Linq;


public class RunAway : MyState
{
    public RunAway(MyFSMAI context) : base(context) { }
    private float distanceWithPredator, X, Y, Z;
    private Vector3 predatorPosition, _fuite, predatorDirection;
    
    
    //Problème à régler !!!!
    //L'instance ne part pas forcément dans la direction opposée du Predateur !

    public override void Transition()
    {
        //Transition vers Wait
        if (Context.PredatorsInRange().Count == 0)
        { Context.CurrentState = new MyWait(Context); }
        //Transition vers Attack
        if (Context.PredatorsInRange().Count == 0 && Context.EnnemiesInRanges().Count != 0)
        { Context.CurrentState = new MyAttack(Context); }
        //Transition vers RunAway
        if (Context.PredatorsInRange().Count != 0)
        { Context.CurrentState = new RunAway(Context);
        }
    }

    public override void SetUp()
    { Predator FirstOrDefault = Context.PredatorsInRange().First();
        predatorPosition = FirstOrDefault.transform.position;
        X = FirstOrDefault.transform.position.x;
        Y = FirstOrDefault.transform.position.y;
        Z = FirstOrDefault.transform.position.z;
        predatorPosition = new Vector3(X, Y, Z);
        predatorDirection = predatorPosition - Context.transform.position;
        distanceWithPredator = Vector3.Distance(predatorDirection, Context.transform.position);
        _fuite = predatorDirection.normalized * distanceWithPredator;
    }

    public override void Do()
    {
        Context.NavMeshAgent.SetDestination(-_fuite);
        Debug.Log("Run !");
    }
}