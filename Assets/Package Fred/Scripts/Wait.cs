using UnityEngine;

public class Wait : State {
    
    public Wait(FSMAI2 context) : base(context) { }
    
    public override void Transition() {
        // Transition vers Move
        if (Input.GetButtonDown("Fire2")) {
            Context.CurrentState = new Move(Context);
        }
        // Transition vers Attack
        if (Context.MonstersInRange().Count > 0) {
            Context.CurrentState = new Attack(Context);
        }
    }

    public override void Setup() { }

    public override void Do() {
        Debug.Log("State : Wait");
    }
    
}