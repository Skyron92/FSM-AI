using UnityEngine;
using System.Linq;
public class BlueRunAway : BlueState
{
    public BlueRunAway(Blue context) : base(context)
    {
    }
    private float distanceWithPredator, X, Y, Z;
    private Vector3 predatorPosition, _fuite, predatorDirection;
    public override void Transition()
    {
        //Transition vers Patroi
        if (BlueContext.PredatorsInRange().Count == 0)
        { BlueContext.CurrentState = new BluePatroi(BlueContext); }
    }

    public override void SetUp()
    {
        Predator FirstOrDefault = BlueContext.PredatorsInRange().First();
        predatorPosition = FirstOrDefault.transform.position;
        X = FirstOrDefault.transform.position.x;
        Y = FirstOrDefault.transform.position.y;
        Z = FirstOrDefault.transform.position.z;
        predatorPosition = new Vector3(X, Y, Z);
        predatorDirection = predatorPosition - BlueContext.transform.position;
        distanceWithPredator = Vector3.Distance(predatorDirection, BlueContext.transform.position);
        _fuite = predatorDirection.normalized * distanceWithPredator;
    }

    public override void Do()
    {
        BlueContext.NavMeshAgent.SetDestination(_fuite);
    }
}