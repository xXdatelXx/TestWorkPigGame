using System;
using System.Collections.Generic;

namespace TestWork.Engine.Factory
{
    public sealed class Pool<TItem> : IPool<TItem>
    {
        private readonly IFactory<TItem> _factory;
        private readonly Stack<TItem> _objects;

        public Pool(IFactory<TItem> factory, Stack<TItem> objects)
        {
            _factory = factory;
            _objects = objects;
        }

        public Pool(IFactory<TItem> factory, IEnumerable<TItem> objects) : this(factory, new Stack<TItem>(objects))
        { }

        public Pool(IFactory<TItem> factory) : this(factory, new Stack<TItem>())
        { }

        public bool Contains(TItem obj) => _objects.Contains(obj);

        public TItem Get() =>
            _objects.Count == 0 ? _factory.Create() : _objects.Pop();

        public void Return(TItem obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (Contains(obj))
                throw new InvalidOperationException("Object already in pool");

            _objects.Push(obj);
        }
    }
}