using System;
using System.Linq;
using UnityEngine;

public class AlphaAttack : AlphaState
{
    public AlphaAttack(Alpha context) : base(context)
    {
    }
    private int _damage = 4; 
    private float TimeSinceLastAttack = 3f;
    

    public override void Transition()
    {
        //Transition vers Run Away
        if (Alpha.Meute().Count <= 3 && AlphaContext.PredatorsInRange().Count > 0)
        { 
            AlphaContext.CurrentState = new AlphaRun(AlphaContext);
        }
    }

    public override void SetUp()
    {
    }

    public override void Do()
    {
        if (TimeSinceLastAttack >= 1f)
        { Predator firstOrDefault = AlphaContext.PredatorsInRange().FirstOrDefault();
            if (firstOrDefault != null)
            { firstOrDefault.TakeDamage(_damage);
                TimeSinceLastAttack = 0f; } }
        TimeSinceLastAttack += Time.deltaTime;
    }
}