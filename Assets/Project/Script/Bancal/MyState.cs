public abstract class MyState
{
    public bool SetupDone;
    protected MyFSMAI Context;
    private int hp = 10;

    protected MyState(MyFSMAI context)
    {
        Context = context;
    }

    public void TakeDamage(int damage)
    { hp -= damage;
        if (hp <= 0)
        { hp = 0;
        }
    }
    public abstract void  Transition();
    public abstract void SetUp();
    public abstract void Do();
}