public abstract class State {

    public bool SetupDone;
    protected FSMAI2 Context;

    protected State(FSMAI2 context) {
        Context = context;
    }

    public abstract void Transition();
    public abstract void Setup();
    public abstract void Do();

}