using System.Linq;
using UnityEngine;

public class Attack : State {

    private float timeSinceLastAttack;
    
    public Attack(FSMAI2 context) : base(context) { }
    
    public override void Transition() {
        // Transition vers Wait
        if (Context.MonstersInRange().Count == 0) {
            Context.CurrentState = new Wait(Context);
        }
    }

    public override void Setup() { }

    public override void Do() {
        if (timeSinceLastAttack >= 1f) {
            Monster firstOrDefault = Context.MonstersInRange().First();
            firstOrDefault.Damage(2);
            Debug.Log("State : Attack - Attack");
            timeSinceLastAttack = 0f;
        }
        timeSinceLastAttack += Time.deltaTime;
        Debug.Log("State : Attack - Reload");
    }

}