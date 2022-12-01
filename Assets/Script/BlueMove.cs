using UnityEngine;

public class BlueMove : BlueState
{
    private Transform _alphaTransform;
    private float distanceWithAlpha;
    private bool HasReachedDestination  => Vector3.Distance(BlueContext.AlphaCreator.transform.position, BlueContext.transform.position) < 0.3f;
    
    public BlueMove(Blue context) : base(context)
    {
    }

    public override void Transition()
    {
        //Loop
        if (HasReachedDestination && BlueContext.PredatorsInRange().Count == 0)
        { BlueContext.CurrentState = new BlueWait(BlueContext); }
        //Transition vers RunAway
        if (BlueContext.PredatorsInRange().Count > 0) {
            foreach (Blue blue in Alpha.Meute()) {
                BlueContext.CurrentState = new BlueRunAway(BlueContext);
            } 
        }
        //Transition vers Attack
        if (BlueContext.PredatorsInRange().Count > 0 && Alpha.Meute().Count > 5)
        {
            foreach (Blue VARIABLE in Alpha.Meute())
            {
                BlueContext.CurrentState = new BLueAttack(BlueContext);
            }
        }
        
    }

    public override void SetUp() {
        _alphaTransform = BlueContext.AlphaCreator.transform;
    }

    public override void Do() {
        BlueContext.NavMeshAgent.SetDestination(_alphaTransform.position);
    }
}