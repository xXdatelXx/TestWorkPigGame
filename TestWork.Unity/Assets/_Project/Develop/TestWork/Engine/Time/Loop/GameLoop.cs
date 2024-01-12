using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace TestWork.Engine.Time
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IGameLoopObject[] _objects;

        public GameLoop(params IGameLoopObject[] loopObject) =>
            _objects = loopObject;

        public GameLoop(List<IGameLoopObject> loopObjects) : this(loopObjects.ToArray())
        { }

        public void Start() =>
            StartAsyncLoop().Forget();

        private async UniTaskVoid StartAsyncLoop()
        {
            while (true)
            {
                foreach (var o in _objects)
                    o.Tick(UnityEngine.Time.deltaTime);

                await UniTask.NextFrame();
            }
        }
    }
}