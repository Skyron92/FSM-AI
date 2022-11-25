using System;
using System.Collections.Generic;
using System.Linq;using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class Hunt : PredatorState
{
    private Vector3 _fsmaiPosition, _fsmaiDirection, _hunt;
    private float X, Y, Z, distanceWithPrey;
    private Vector3 _target;
    private bool HasReachedDestination => Vector3.Distance(_target, PredatorContext.transform.position) < 0.1f;
    public Hunt(Predator context) : base(context)
    {
    }



    public override void Transition()
    {
        //Loop
        if (PredatorContext.MyFsmaiInFieldOfView().Count != 0)
        { PredatorContext.CurrentState = new Hunt(PredatorContext);
        }
        //Transition vers Patroi
        if (PredatorContext.MyFsmaiInFieldOfView().Count == 0)
        { PredatorContext.CurrentState = new Patroi(PredatorContext);
        }
        //Transition vers Attack
        if (PredatorContext.MyFsmaiInRange().Count != 0)
        { PredatorContext.CurrentState = new Hurt(PredatorContext);
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
        Debug.Log("la chasse est ouverte");
    }
}