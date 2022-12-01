using System.Linq;
using UnityEngine;

public class BLueAttack : BlueState
{
    public BLueAttack(Blue context) : base(context)
    {
    }
    private int _damage = 4; 
    private float TimeSinceLastAttack = 3f;

    public override void Transition()
    {
        //Transition vers Run Away
        if (Alpha.Meute().Count <= 3)
        { 
            BlueContext.CurrentState = new BlueRunAway(BlueContext);
        }
    }

    public override void SetUp()
    {
        
    }

    public override void Do()
    {
        if (TimeSinceLastAttack >= 1f)
        { Predator firstOrDefault = BlueContext.PredatorsInRange().FirstOrDefault();
            if (firstOrDefault != null)
            { firstOrDefault.TakeDamage(_damage);
                TimeSinceLastAttack = 0f; } }
        TimeSinceLastAttack += Time.deltaTime;
    }
}