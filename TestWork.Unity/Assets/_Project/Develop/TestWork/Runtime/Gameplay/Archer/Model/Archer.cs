using System;
using Cysharp.Threading.Tasks;
using TestWork.Gameplay.Extensions;
using UnityEngine;

namespace TestWork.Gameplay
{
    public sealed class Archer : IArcher
    {
        private readonly Transform _transform;
        private readonly IMap<Enemy> _map;
        private readonly IBow _bow;
        private readonly IAim _aim;
        private Enemy _target;

        public Archer(Transform transform, IMap<Enemy> map, IBow bow, IAim aim)
        {
            _transform = transform;
            _map = map;
            _bow = bow;
            _aim = aim;
        }

        public bool HasTarget() => _aim.Observing && _target != null && _target.Alive();

        public bool CanAttack() => HasTarget() && _bow.CanShoot;

        public void FindTarget()
        {
            _target = null;

            Async().Forget();
            return;

            async UniTaskVoid Async()
            {
                Enemy e = _map.FindNearest(_transform);
                if (e == null)
                    return;

                _aim.Observe(e.transform);
                await _aim.WaitUntilObserving();

                _target = e;
            }
        }

        public void AttackTarget()
        {
            if (!CanAttack())
                throw new InvalidOperationException(nameof(CanAttack));

            _target = null;
            _bow.Shoot();
        }
    }
}