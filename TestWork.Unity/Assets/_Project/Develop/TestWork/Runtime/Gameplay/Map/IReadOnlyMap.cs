using System.Collections.Generic;

namespace TestWork.Gameplay
{
    public interface IReadOnlyMap<out TObject>
    {
        IReadOnlyList<TObject> Find();
    }
}