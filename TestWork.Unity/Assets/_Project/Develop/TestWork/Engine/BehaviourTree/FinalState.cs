namespace TestWork.Engine.BehaviourTree
{
    // Empty state for tests or not behaviour objects
    public sealed class FinalState : IBehaviourState
    {
        public IBehaviourState Execute(float time)
        {
            return this;
        }
    }
}