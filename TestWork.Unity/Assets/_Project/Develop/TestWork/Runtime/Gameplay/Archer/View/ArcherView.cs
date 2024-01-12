using Cysharp.Threading.Tasks;
using TestWork.Engine.Time;
using UnityEngine;

namespace TestWork.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public sealed class ArcherView : MonoBehaviour, IArcherView
    {
        [SerializeField] private string _shootAnimation;
        [SerializeField] private float _shootDuration;
        [SerializeField] private Animator _animator;
        public bool AnimationPlaying { get; private set; }

        private void OnValidate() =>
            _animator = GetComponent<Animator>();

        public async UniTask Attack()
        {
            AnimationPlaying = true;
            _animator.Play(_shootAnimation);

            await new AsyncTimer(_shootDuration).PlayAndWaitEnd();
            AnimationPlaying = false;
        }
    }
}