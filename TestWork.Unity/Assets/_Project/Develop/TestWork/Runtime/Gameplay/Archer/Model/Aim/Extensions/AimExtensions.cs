using Cysharp.Threading.Tasks;

namespace TestWork.Gameplay.Extensions
{
    public static class AimExtensions
    {
        public static async UniTask WaitUntilObserving(this IAim aim) =>
            await UniTask.WaitUntil(() => aim.Observing);
    }
}