using TestWork.Engine.Unity;
using VContainer.Unity;

namespace TestWork.Runtime.Core
{
    public sealed class Bootstrap : IStartable
    {
        private readonly IScene _entry;

        public Bootstrap(IScene entry) =>
            _entry = entry;

        public void Start() =>
            _entry.Open();
    }
}