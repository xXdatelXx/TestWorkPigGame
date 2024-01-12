using UnityEngine;

namespace TestWork.Gameplay
{
    public interface IAim
    {
        bool Observing { get; }
        void Observe(Transform target);
    }
}