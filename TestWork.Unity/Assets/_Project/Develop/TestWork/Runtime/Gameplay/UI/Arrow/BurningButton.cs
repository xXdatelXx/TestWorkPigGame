using TestWork.Engine.UI;

namespace TestWork.Gameplay
{
    public sealed class BurningButton : IButton
    {
        private readonly ArrowConfig _config;
        private readonly float _damageAffect;
        private bool _burning;

        public BurningButton(ArrowConfig config, float damageAffect)
        {
            _config = config;
            _damageAffect = damageAffect;
        }

        public void Press()
        {
            _burning = !_burning;
            _config.Damage = _burning ? _config.Damage + _damageAffect : _config.Damage - _damageAffect;
        }
    }
}