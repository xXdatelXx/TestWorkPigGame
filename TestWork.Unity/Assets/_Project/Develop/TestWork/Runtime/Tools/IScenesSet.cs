using TestWork.Engine.Unity;

namespace TestWork.Runtime.Tools
{
    public interface IScenesSet
    {
        IScene Meta { get; }
        IScene Game { get; }
        IScene Empty { get; }
    }
}