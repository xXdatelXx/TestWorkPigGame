namespace TestWork.Gameplay
{
    public sealed class EnemyHealth : IHealth
    {
        private readonly IHealth _origin;
        private readonly Enemy _enemy;
        private readonly IMap<Enemy> _map;

        public EnemyHealth(IHealth origin, Enemy enemy, IMap<Enemy> map)
        {
            _origin = origin;
            _enemy = enemy;
            _map = map;
        }

        public bool Alive() => _origin.Alive() && _map.Exist(_enemy);

        public void TakeDamage(float d)
        {
            _origin.TakeDamage(d);
            if (!Alive())
            {
                _map.Remove(_enemy);
                _enemy.gameObject.SetActive(false);
            }
        }
    }
}