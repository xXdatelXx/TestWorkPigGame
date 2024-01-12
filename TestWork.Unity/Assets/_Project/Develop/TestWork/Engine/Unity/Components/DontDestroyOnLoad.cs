using UnityEngine;

namespace TestWork.Engine.Unity
{
    [DisallowMultipleComponent]
    public sealed class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() =>
            DontDestroyOnLoad(this);
    }
}