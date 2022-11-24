using System.Linq;
using UnityEngine;

public class MyAttack : MyState
{
    private int _damage = 2; 
    private float TimeSinceLastAttack = 3f;
    public MyAttack(MyFSMAI context) : base(context)
    {
    }

    public override void Transition()
    {
        //transition vers Wait
        if (Context.EnnemiesInRanges().Count == 0)
        {
            Context.CurrentState = new MyWait(Context);
        }
    }

    public override void SetUp() { }

    public override void Do()
    {
        if (TimeSinceLastAttack >= 1f)
        {
            Ennemy firstOrDefault = Context.EnnemiesInRanges().First();
            firstOrDefault.Damage(2);
            TimeSinceLastAttack = 0f;
        }

        TimeSinceLastAttack += Time.deltaTime;
    }
}