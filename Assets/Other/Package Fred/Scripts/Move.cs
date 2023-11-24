using UnityEngine;

public class Move : State {
    
    private Vector3 _moveTarget;

    private bool HasReachedDestination => Vector3.Distance(_moveTarget, Context.transform.position) < 0.1f;
    
    public Move(FSMAI2 context) : base(context) { }
    
    public override void Transition() {
        // Transition vers Wait
        if (HasReachedDestination) {
            Context.CurrentState = new Wait(Context);
        }
        // Transition vers Move
        if (Input.GetButtonDown("Fire2")) {
            Context.CurrentState = new Move(Context);
        }
    }

    public override void Setup() {
        if (Camera.main != null) {
            _moveTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _moveTarget.y = Context.transform.position.y;
        }
    }

    public override void Do() {
        Debug.Log("State : Move");
        Context.NavMeshAgent.SetDestination(_moveTarget);
    }
    
}