namespace TestWork.Gameplay
{
    public interface IBow
    {
        void Shoot();
        bool CanShoot { get; }
    }
}