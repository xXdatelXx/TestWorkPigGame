namespace TestWork.Engine.BehaviourTree
{
    // Simple realisation of behaviour tree 
    public interface IBehaviourState
    {
        IBehaviourState Execute(float time);
    }
}