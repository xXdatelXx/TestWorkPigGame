using TestWork.Engine.Factory;
using UnityEngine;

namespace TestWork.Gameplay
{
    // Test script
    public sealed class EnemyFactory : IFactory<Enemy>
    {
        private readonly IMap<Enemy> _map;
        private readonly Enemy _enemy;
        private readonly Transform _center;
        private readonly float _radius;

        public EnemyFactory(IMap<Enemy> map, Enemy enemy, Transform center, float radius)
        {
            _map = map;
            _enemy = enemy;
            _center = center;
            _radius = radius;
        }

        public Enemy Create()
        {
            _map.Add(_enemy);

            IHealth health = new Health(1);
            IHealth healthInMap = new EnemyHealth(health, _enemy, _map);
            IHealth verboseHealth = new VerboseHealth(healthInMap);
            IHealth strictHealth = new StrictHealth(verboseHealth);

            _enemy.transform.position = Random.insideUnitCircle * _radius;
            _enemy.Construct(strictHealth);
            _enemy.gameObject.SetActive(true);

            return _enemy;
        }
    }
}