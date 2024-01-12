using Cysharp.Threading.Tasks;

namespace TestWork.Gameplay
{
    public sealed class ArcherWithView : IArcher
    {
        private readonly IArcher _origin;
        private readonly IArcherView _view;

        public ArcherWithView(IArcher origin, IArcherView view)
        {
            _origin = origin;
            _view = view;
        }

        public bool HasTarget() =>
            _origin.HasTarget();

        public bool CanAttack() =>
            _origin.CanAttack() && !_view.AnimationPlaying;

        public void FindTarget() =>
            _origin.FindTarget();

        public void AttackTarget() =>
            AttackAsync().Forget();

        private async UniTaskVoid AttackAsync()
        {
            await _view.Attack();
            _origin.AttackTarget();
        }
    }
}