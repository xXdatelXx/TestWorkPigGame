using UnityEngine;

namespace TestWork.Gameplay
{
    public sealed class VerboseHealth : IHealth
    {
        private readonly IHealth _origin;

        public VerboseHealth(IHealth origin) =>
            _origin = origin;

        public bool Alive() => _origin.Alive();

        public void TakeDamage(float d)
        {
            _origin.TakeDamage(d);

            Debug.Log($"Damage: {d}");

            if (_origin.Died())
                Debug.Log("Died");
        }
    }
}