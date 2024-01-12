using TestWork.Engine.BehaviourTree;

namespace TestWork.Gameplay
{
    public sealed class ArcherFindTarget : IBehaviourState
    {
        private readonly IArcher _character;

        public ArcherFindTarget(IArcher character) =>
            _character = character;

        public IBehaviourState Execute(float time)
        {
            if (_character.HasTarget())
                return new ArcherAttack(_character).Execute(time);

            _character.FindTarget();

            return this;
        }
    }
}