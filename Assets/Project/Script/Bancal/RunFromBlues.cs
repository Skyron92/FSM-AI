using System.Linq;
using UnityEngine;

public class RunFromBlues : MyState
{
    public RunFromBlues(MyFSMAI context) : base(context)
    {
    }

    private float distance, X,Y,Z;
    private Vector3 positionBlue, directionBlue, _fuite;

    public override void Transition()
    {
        //Transition vers Wait
        if (Context.BLuesInRange().Count <2)
        { Context.CurrentState = new MyWait(Context); }
        //Loop
        if (Context.BLuesInRange().Count >= 2)
        { Context.CurrentState = new RunFromBlues(Context); }
    }

    public override void SetUp()
    {
        Blue FirstOrDefault = Context.BLuesInRange().FirstOrDefault();
        X = FirstOrDefault.transform.position.x;
        Y = FirstOrDefault.transform.position.y;
        Z = FirstOrDefault.transform.position.z;
        positionBlue = new Vector3(X, Y, Z);
        directionBlue = positionBlue - Context.transform.position;
        distance = Vector3.Distance(directionBlue, Context.transform.position);
        _fuite = directionBlue.normalized * distance;
    }
    

    public override void Do()
    { Context.NavMeshAgent.SetDestination(_fuite); }
}