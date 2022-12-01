using System.Linq;
using UnityEngine;

public class AlphaRun : AlphaState
{
    public AlphaRun(Alpha context) : base(context) {}
    private float distanceWithPredator, X, Y, Z;
    private Vector3 predatorPosition, _fuite, predatorDirection;

    public override void Transition()
    { if (AlphaContext.PredatorsInRange().Count == 0)
        { AlphaContext.CurrentState = new AlphaPatroi(AlphaContext); } }

    public override void SetUp()
    { Predator FirstOrDefault = AlphaContext.PredatorsInRange().First();
        predatorPosition = FirstOrDefault.transform.position;
        X = FirstOrDefault.transform.position.x;
        Y = FirstOrDefault.transform.position.y;
        Z = FirstOrDefault.transform.position.z;
        predatorPosition = new Vector3(X, Y, Z);
        predatorDirection = predatorPosition - AlphaContext.transform.position;
        distanceWithPredator = Vector3.Distance(predatorDirection, AlphaContext.transform.position);
        _fuite = predatorDirection.normalized * distanceWithPredator; }

    public override void Do()
    { AlphaContext.NavMeshAgent.SetDestination(- _fuite); }
}