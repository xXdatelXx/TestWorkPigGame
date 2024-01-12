using Cysharp.Threading.Tasks;

namespace TestWork.Gameplay
{
    public interface IArcherView
    {
        bool AnimationPlaying { get; }
        UniTask Attack();
    }
}