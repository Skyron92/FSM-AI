using System;
using System.Collections.Generic;
using System.Linq;using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class Hunt : PredatorState
{
    private Vector3 _fsmaiPosition, _fsmaiDirection, _bluePos, _blueDirect, _huntP, _huntB, _hunt;
    private float X, Y, Z, distanceWithPrey, distanceBlue;
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
        if (PredatorContext.MyFsmaiInFieldOfView().Count == 0 && PredatorContext.BluesInFieldOfView().Count == 0)
        { PredatorContext.CurrentState = new Patroi(PredatorContext);
        }
        //Transition vers Attack
        if (PredatorContext.MyFsmaiInRange().Count != 0 || PredatorContext.BlueInRange().Count != 0)
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
        _huntP = _fsmaiDirection.normalized * distanceWithPrey;
        
        Blue First = PredatorContext.BluesInFieldOfView().First();
        _bluePos = First.transform.position;
        X = First.transform.position.x;
        Y = First.transform.position.y;
        Z = First.transform.position.z;
        _bluePos = new Vector3(X, Y, Z);
        _blueDirect = _bluePos - PredatorContext.transform.position;
        distanceBlue = Vector3.Distance(_blueDirect, PredatorContext.transform.position);
        _huntB = _blueDirect.normalized * distanceBlue;

        if (distanceBlue <= distanceWithPrey)
        {
            _hunt = _huntB;
        }
        else
        {
            _hunt = _huntP;
        }
    }

    public override void Do()
    {
        PredatorContext.NavMeshAgent.SetDestination(_hunt);
        Debug.Log("la chasse est ouverte");
    }
}