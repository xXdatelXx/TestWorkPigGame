using TestWork.Engine.BehaviourTree;

namespace TestWork.Gameplay
{
    public sealed class ArcherAttack : IBehaviourState
    {
        private readonly IArcher _character;

        public ArcherAttack(IArcher character) =>
            _character = character;

        public IBehaviourState Execute(float time)
        {
            if (_character.HasTarget() == false)
                return new ArcherFindTarget(_character).Execute(time);
            if (_character.CanAttack() == false)
                return this;

            _character.AttackTarget();

            return this;
        }
    }
}