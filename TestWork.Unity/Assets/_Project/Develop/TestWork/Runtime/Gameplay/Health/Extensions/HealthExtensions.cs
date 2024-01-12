namespace TestWork.Gameplay
{
    public static class HealthExtensions
    {
        public static bool Died(this IReadOnlyHealth health) =>
            health.Alive() == false;
    }
}