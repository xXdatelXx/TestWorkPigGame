namespace TestWork.Gameplay
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(float d);
    }
}