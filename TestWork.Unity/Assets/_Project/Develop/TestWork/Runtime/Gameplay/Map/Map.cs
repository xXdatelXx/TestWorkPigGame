using System;
using System.Collections.Generic;

namespace TestWork.Gameplay
{
    public sealed class Map<TObject> : IMap<TObject>
    {
        private readonly List<TObject> _objects;

        public Map(List<TObject> objects) =>
            _objects = objects;

        public Map() : this(new List<TObject>())
        { }

        public IReadOnlyList<TObject> Find() =>
            _objects;

        public bool Exist(TObject o)
        {
            if (o == null)
                throw new ArgumentNullException(nameof(o));

            return _objects.Contains(o);
        }

        public void Add(TObject o)
        {
            if (Exist(o))
                throw new InvalidOperationException("Object already in map");

            _objects.Add(o);
        }

        public void Remove(TObject o)
        {
            if (!Exist(o))
                throw new InvalidOperationException("Object already in map");

            _objects.Remove(o);
        }
    }
}