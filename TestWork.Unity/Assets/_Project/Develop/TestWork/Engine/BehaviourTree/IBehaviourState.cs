namespace TestWork.Engine.BehaviourTree
{
    public interface IBehaviourState
    {
        IBehaviourState Execute(float time);
    }
}