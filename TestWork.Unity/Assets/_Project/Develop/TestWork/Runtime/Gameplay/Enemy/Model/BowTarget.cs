using TestWork.Engine.BehaviourTree;

namespace TestWork.Gameplay
{
    public sealed class BowTarget : Enemy
    {
        protected override IBehaviourState CreateBehaviour()
        {
            return new FinalState();
        }
    }
}