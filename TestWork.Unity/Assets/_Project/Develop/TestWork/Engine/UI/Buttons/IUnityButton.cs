namespace TestWork.Engine.UI
{
    // Unity UI button adapter for convenient click event subscription 
    public interface IUnityButton
    {
        void Subscribe(IButton button);
    }
}