using UnityEngine;

namespace TestWork.Engine.Factory
{
    public sealed class MonoBehaviourFactory<TObject> : IFactory<TObject> where TObject : MonoBehaviour
    {
        private readonly TObject _prefab;
        private readonly Transform _parent;

        public MonoBehaviourFactory(TObject prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public TObject Create() =>
            Object.Instantiate(_prefab, _parent);
    }
}