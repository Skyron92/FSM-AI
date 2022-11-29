using UnityEngine;

public class BlueMove : BlueState
{
    private Vector3 _target;
    private float distanceWithAlpha;
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
        //Transition vers RunAway
        if (BlueContext.PredatorsInRange().Count > 0)
        { foreach (Blue blue in Alpha.Meute())
            { BlueContext.CurrentState = new BlueRunAway(BlueContext); } }
    }

    public override void SetUp()
    { if (Alpha.Meute().Contains(BlueContext))
        { _target = BlueContext.AlphaPositionForBlue; } }

    public override void Do()
    { BlueContext.NavMeshAgent.SetDestination(_target); }
}