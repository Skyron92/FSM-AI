using UnityEngine;

public abstract class AlphaState
{
    protected Alpha AlphaContext;
    private int _alphaHp;
    public bool setUpDone, isAnAlpha;
   
    protected AlphaState(Alpha context)
    { AlphaContext = context; }
    public abstract void Transition();
    public abstract void SetUp();
    public abstract void Do();
}