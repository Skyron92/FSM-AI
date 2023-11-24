using System.Linq;
using UnityEngine;

public class Hurt : PredatorState //Dans cet état, le predator attaque sa cible 
{
    public Hurt(Predator context) : base(context)
    {
    }
    
    private float TimeSinceLastAttack = 3f;

    public override void Transition()
    {
        //Transition vers Patroi
        if (PredatorContext.MyFsmaiInRange().Count == 0)
        { PredatorContext.CurrentState = new Patroi(PredatorContext);
        }
    }

    public override void SetUp() {}

    public override void Do()
    {
        if (TimeSinceLastAttack >= 1f)
        { MyFSMAI firstOrDefault = PredatorContext.MyFsmaiInRange().FirstOrDefault();
            if (firstOrDefault != null)
            { firstOrDefault.Damage(PredatorContext.Damage);
                TimeSinceLastAttack = 0f; } }
        TimeSinceLastAttack += Time.deltaTime;
    }
}