namespace TestWork.Gameplay
{
    public interface IMap<TObject> : IReadOnlyMap<TObject>
    {
        bool Exist(TObject o);
        void Add(TObject o);
        void Remove(TObject o);
    }
}