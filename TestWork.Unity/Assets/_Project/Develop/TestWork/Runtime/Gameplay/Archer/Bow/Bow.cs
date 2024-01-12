using System;
using TestWork.Engine.Factory;
using TestWork.Engine.Time;

namespace TestWork.Gameplay
{
    public sealed class Bow : IBow
    {
        private readonly IFactory<IArrow> _quiver;
        private readonly float _force;
        private readonly ITimer _reload;

        public Bow(IFactory<IArrow> quiver, float force, ITimer reload)
        {
            _quiver = quiver;
            _force = force;
            _reload = reload;
        }

        public Bow(IFactory<IArrow> quiver, float force, float reload) : this(quiver, force, new AsyncTimer(reload))
        { }

        public bool CanShoot => _reload.Rest();

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException("Bow is reloading and cant shoot");

            IArrow a = _quiver.Create();
            a.Throw(_force);
            _reload.Play();
        }
    }
}