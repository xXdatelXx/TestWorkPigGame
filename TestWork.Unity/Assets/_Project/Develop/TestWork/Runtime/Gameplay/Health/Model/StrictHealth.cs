using System;

namespace TestWork.Gameplay
{
    //IHealth realization for avoid code duplication of assertions
    public sealed class StrictHealth : IHealth
    {
        private readonly IHealth _origin;

        public StrictHealth(IHealth origin) =>
            _origin = origin;

        public bool Alive() => _origin.Alive();

        public void TakeDamage(float d)
        {
            if (!Alive())
                throw new InvalidOperationException("Object already died");
            if (d < 0)
                throw new ArgumentOutOfRangeException("TakeDamage cant be sub zero");

            _origin.TakeDamage(d);
        }
    }
}