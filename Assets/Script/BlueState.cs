using UnityEngine;

public abstract class BlueState : MonoBehaviour
{
    protected Blue BlueContext;
    private int _blueHp;
    public bool setUpDone, isAnAlpha;

    protected BlueState(Blue context)
    { BlueContext = context;
    }
    public abstract void Transition();
    public abstract void SetUp();
    public abstract void Do();
}