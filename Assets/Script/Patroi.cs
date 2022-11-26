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
    private float currentx, currentz;
    private bool HasReachedDestination => Vector3.Distance(_target, PredatorContext.transform.position) < 0.1f;

    public override void Transition()
    {
        //Loop
        if (HasReachedDestination)
        { PredatorContext.CurrentState = new Patroi(PredatorContext);
        }
        //Transition vers Hunt
        if (PredatorContext.MyFsmaiInFieldOfView().Count >0)
        { PredatorContext.CurrentState = new Hunt(PredatorContext);
        }
        //Transition vers Hurt
        if (PredatorContext.MyFsmaiInRange().Count > 0)
        { PredatorContext.CurrentState = new Hurt(PredatorContext);
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