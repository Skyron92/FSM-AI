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
        { BlueContext.CurrentState = new BlueWait(BlueContext); }
        //Transition vers RunAway
        if (BlueContext.PredatorsInRange().Count > 0)
        { foreach (Blue blue in Alpha.Meute())
            { BlueContext.CurrentState = new BlueRunAway(BlueContext); } }
    }

    public override void SetUp()
    { _target = BlueContext.AlphaCreator.transform.position; 
             }

    public override void Do()
    {Debug.Log(_target);
        BlueContext.NavMeshAgent.SetDestination(_target); }
}