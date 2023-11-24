using UnityEngine;

public abstract class EnnemyState : MonoBehaviour
{

    protected Ennemy Context;


    protected EnnemyState(Ennemy context)
    {
        Context = context;
    }
    public abstract void Transition();
    public abstract void SetUp();
    public abstract void Do();
}
