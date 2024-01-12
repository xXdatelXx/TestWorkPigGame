using TestWork.Engine.Unity;
using VContainer.Unity;

namespace TestWork.Runtime.Core
{
    public sealed class Meta : IStartable
    {
        private readonly IScene _game;

        public Meta(IScene game) =>
            _game = game;

        public void Start() =>
            _game.Open();
    }
}