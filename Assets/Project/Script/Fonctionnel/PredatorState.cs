using Palmmedia.ReportGenerator.Core.Parser.Analysis;using UnityEngine;

public abstract class PredatorState : MonoBehaviour //Cette classe est la classe mère de tous les états possible de ma classe Predator
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