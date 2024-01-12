using TestWork.Engine.BehaviourTree;
using TestWork.Engine.Time;
using UnityEngine;

namespace TestWork.Gameplay
{
    [RequireComponent(typeof(IHealth))]
    public abstract class Enemy : MonoBehaviour, IHealth, IGameLoopObject
    {
        private IHealth _health;
        private IBehaviourState _behaviour;

        public void Construct(IHealth health)
        {
            _health = health;
            _behaviour = CreateBehaviour();
        }

        public bool Alive() => _health.Alive();
        public void TakeDamage(float d) => _health.TakeDamage(d);

        public void Tick(float deltaTime) =>
            _behaviour.Execute(deltaTime);

        protected abstract IBehaviourState CreateBehaviour();
    }
}