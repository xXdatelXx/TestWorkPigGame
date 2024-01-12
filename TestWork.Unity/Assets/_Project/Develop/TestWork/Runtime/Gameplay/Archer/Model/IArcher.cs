namespace TestWork.Gameplay
{
    public interface IArcher
    {
        bool HasTarget();
        bool CanAttack();
        void FindTarget();
        void AttackTarget();
    }
}