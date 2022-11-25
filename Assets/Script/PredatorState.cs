using UnityEngine;

public abstract class PredatorState : MonoBehaviour
{
    protected Predator PredatorContext;
    private int _predatorHP;
    public bool SetUpDone;

    protected PredatorState(Predator context)
    { PredatorContext = context;
    }
    public abstract void Transition();
    public abstract void SetUp();
    public abstract void Do();
}