using Cysharp.Threading.Tasks;

namespace TestWork.Engine.Time
{
    public static class TimerExtension
    {
        public static bool Rest(this IReadOnlyTimer t) =>
            !t.Playing;

        public static async UniTask End(this IReadOnlyTimer t) =>
            await UniTask.WaitUntil(t.Rest);

        public static async UniTask PlayAndWaitEnd(this ITimer t)
        {
            t.Play();
            await t.End();
        }
    }
}