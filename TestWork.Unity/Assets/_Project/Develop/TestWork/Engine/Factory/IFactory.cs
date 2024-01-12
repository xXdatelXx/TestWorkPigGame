namespace TestWork.Engine.Factory
{
    public interface IFactory<out T>
    {
        T Create();
    }
}