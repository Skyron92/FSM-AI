using UnityEngine.UI;

public abstract class MyState
{
    public bool SetupDone;
    protected MyFSMAI Context;

    protected MyState(MyFSMAI context)
    {
        Context = context;
    }
    
    public abstract void  Transition();
    public abstract void SetUp();
    public abstract void Do();
}