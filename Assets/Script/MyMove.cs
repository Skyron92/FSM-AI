using UnityEngine;

public class MyMove : MyState
{

    private Vector3 _moveTarget;
    

    private bool HasReachedDestintaion => Vector3.Distance(_moveTarget, Context.transform.position) < 0.1f;
    public MyMove(MyFSMAI context) : base(context) { }

    public override void Transition()
    {
        //Transition vers Wait
        if (HasReachedDestintaion)
        { Context.CurrentState = new MyWait(Context); }
        //Transition vers Move
        if (Input.GetButtonDown("Fire2"))
        { Context.CurrentState = new MyMove(Context); }
    }

    public override void SetUp()
    {
        if (Context.camera != null)
        {
            _moveTarget = Context.camera.ScreenToWorldPoint(Input.mousePosition);
            _moveTarget.y = Context.transform.position.y;
        }   
    }

    public override void Do()
    {
        Context.NavMeshAgent.SetDestination(_moveTarget);
    }
}