using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlphaPatroi : AlphaState
{
    private float _rangeX, _rangeZ;
    private Vector3 _target;
    
    private bool HasReachedDestination => Vector3.Distance(_target, AlphaContext.transform.position) < 0.1f;
    public AlphaPatroi(Alpha context) : base(context) {}

    public override void Transition()
    { //Loop
        if (HasReachedDestination)
        { AlphaContext.CurrentState = new AlphaPatroi(AlphaContext); }
    }

    public override void SetUp()
    {
        _rangeX = Random.Range(1, 15);
        _rangeZ = Random.Range(1, 15);
        _target = new Vector3(_rangeX, AlphaContext.transform.position.y, _rangeZ);
    }

    public override void Do()
    { AlphaContext.NavMeshAgent.SetDestination(_target);
        if (AlphaContext.chance >= 9990)
        { Instantiate(AlphaContext.prefabBlue, AlphaContext.transform.position, Quaternion.identity); }
    }

   
     
        
        
}