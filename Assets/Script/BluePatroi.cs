using UnityEngine;

public class BluePatroi : BlueState
{
    public BluePatroi(Blue context) : base(context)
    {
    }

    private float _rangeX, _rangeZ;
    private Vector3 _target; 
    private bool HasReachedDestination => Vector3.Distance(_target, BlueContext.transform.position) < 0.1f;

    public override void Transition()
    {
        //Loop
        if (HasReachedDestination)
        { BlueContext.CurrentState = new BluePatroi(BlueContext); }
        //Transition vers BlueMove
        if (BlueContext.distanceWithAlpha > 1)
        { BlueContext.CurrentState = new BlueMove(BlueContext);
        }
    }

    public override void SetUp()
    {
        _rangeX = Random.Range(1, 15);
        _rangeZ = Random.Range(1, 15);
        _target = new Vector3(_rangeX, BlueContext.transform.position.y, _rangeZ);
    }

    public override void Do()
    { BlueContext.NavMeshAgent.SetDestination(_target);
    }
}