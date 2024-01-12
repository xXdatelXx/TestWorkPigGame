namespace TestWork.Engine.BehaviourTree
{
    public sealed class FinalState : IBehaviourState
    {
        public IBehaviourState Execute(float time)
        {
            return this;
        }
    }
}