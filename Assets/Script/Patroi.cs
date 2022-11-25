using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Patroi : PredatorState
{
    public Patroi(Predator context) : base(context)
    {
    }

    private float rangeX, rangeZ;
    private Vector3 _target;
    private bool HasReachedDestination => Vector3.Distance(_target, PredatorContext.transform.position) < 0.1f;

    public override void Transition()
    {
        if (HasReachedDestination)
        { PredatorContext.CurrentState = new Patroi(PredatorContext);
        }
    }

    public override void SetUp()
    { rangeX = Random.Range(1, 15);
        rangeZ = Random.Range(1, 15);

        _target = new Vector3(rangeX, PredatorContext.transform.position.y, rangeZ);
    }

    public override void Do()
    {
        PredatorContext.NavMeshAgent.SetDestination(_target);
    }
}