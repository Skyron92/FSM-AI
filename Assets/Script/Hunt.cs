using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hunt : PredatorState
{
    private Vector3 _fsmaiPosition, _fsmaiDirection, _hunt;
    private float X, Y, Z, distanceWithPrey;
    public Hunt(Predator context) : base(context)
    {
    }

    

    public override void Transition()
    {
        //Loop
        if (PredatorContext.MyFsmaiInFieldOfView().Count > 0)
        { PredatorContext.CurrentState = new Hunt(PredatorContext);
        }
        //TRansition vers Patroi
        if (PredatorContext.MyFsmaiInFieldOfView().Count == 0)
        { PredatorContext.CurrentState = new Patroi(PredatorContext);
        }
    }

    public override void SetUp()
    {
        MyFSMAI FirstOrDefault = PredatorContext.MyFsmaiInFieldOfView().First();
        _fsmaiPosition = FirstOrDefault.transform.position;
        X = FirstOrDefault.transform.position.x;
        Y = FirstOrDefault.transform.position.y;
        Z = FirstOrDefault.transform.position.z;
        _fsmaiPosition = new Vector3(X, Y, Z);
        _fsmaiDirection = _fsmaiPosition - PredatorContext.transform.position;
        distanceWithPrey = Vector3.Distance(_fsmaiDirection, PredatorContext.transform.position);
        _hunt = _fsmaiDirection.normalized * distanceWithPrey;
    }

    public override void Do()
    {
        PredatorContext.NavMeshAgent.SetDestination(_hunt);
    }
}