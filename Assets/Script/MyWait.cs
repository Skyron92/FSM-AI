using UnityEngine;

public class MyWait : MyState
{
    public MyWait(MyFSMAI context) : base(context) { }

    public override void Transition()
    {
        //Transition vers Move
        if (Input.GetButtonDown("Fire2"))
        {
            Context.CurrentState = new MyMove(Context);
        }
        //Transition vers Attack
    }

    public override void SetUp() {}

    public override void Do()
    {
        Debug.Log("Waiting...");
    }
}