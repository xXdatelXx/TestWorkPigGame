using System;

namespace TestWork.Gameplay
{
    public sealed class Health : IHealth
    {
        private float _points;

        public Health(float points) =>
            _points = points;

        public bool Alive() => _points > 0;

        public void TakeDamage(float d) =>
            _points = Math.Max(_points - d, 0);
    }
}