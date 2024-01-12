using System.Collections.Generic;
using UnityEngine;

namespace TestWork.Gameplay
{
    public sealed class LimitedMap<TObject> : IMap<TObject> where TObject : MonoBehaviour
    {
        private readonly IMap<TObject> _origin;
        private readonly Transform _center;
        private readonly float _radius;

        public IReadOnlyList<TObject> Find()
        {
            return _origin.FindInRadius(_center, _radius);
        }

        public bool Exist(TObject o) => _origin.Exist(o);

        public void Add(TObject o) => _origin.Add(o);

        public void Remove(TObject o) => _origin.Remove(o);
    }
}