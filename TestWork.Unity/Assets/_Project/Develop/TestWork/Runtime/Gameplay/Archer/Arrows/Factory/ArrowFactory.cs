using System.Collections.Generic;
using System.Linq;
using TestWork.Engine.Factory;
using UnityEngine;

namespace TestWork.Gameplay
{
    public sealed class ArrowFactory : IFactory<PhysicArrow>
    {
        private readonly ArrowConfig _config;
        private readonly IPool<PhysicArrow> _pool;
        private readonly List<PhysicArrow> _active;
        private readonly Transform _startPoint;
        private readonly float _maxActiveArrows;

        public ArrowFactory(ArrowConfig config, IPool<PhysicArrow> pool, Transform startPoint, float maxActiveArrows)
        {
            _config = config;
            _pool = pool;
            _active = new();
            _startPoint = startPoint;
            _maxActiveArrows = maxActiveArrows;
        }

        public PhysicArrow Create()
        {
            var arrow = _pool.Get();
            arrow.Construct(_config.Damage, _config.Sprite);
            arrow.gameObject.SetActive(true);
            arrow.transform.position = _startPoint.position;
            arrow.transform.rotation = _startPoint.rotation;

            _active.Add(arrow);

            if (_active.Count > _maxActiveArrows)
                _pool.Return(_active.First());

            return arrow;
        }
    }
}