using UnityEngine;

public class BlueMove : BlueState
{
    private Vector3 _target;
    private bool HasReachedDestination  => Vector3.Distance(_target, BlueContext.transform.position) < 0.3f;
    public BlueMove(Blue context) : base(context)
    {
    }

    public override void Transition()
    {
        //Loop
        if (HasReachedDestination)
        { BlueContext.CurrentState = new BlueMove(BlueContext); }
        //Transition vers BluePatroi
        if (BlueContext.distanceWithAlpha < 0.3)
        { BlueContext.CurrentState = new BluePatroi(BlueContext); }
    }

    public override void SetUp()
    { if (Alpha.Meute().Contains(BlueContext))
        { _target = BlueContext.AlphaPosition; } }

    public override void Do()
    { BlueContext.NavMeshAgent.SetDestination(_target); }
}