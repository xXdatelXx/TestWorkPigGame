using TestWork.Engine.Factory;

namespace TestWork.Engine.UI
{
    public sealed class FactoryButton<TObject> : IButton
    {
        private readonly IFactory<TObject> _factory;

        public FactoryButton(IFactory<TObject> factory) =>
            _factory = factory;

        public void Press() =>
            _factory.Create();
    }
}