using TestWork.Engine.Unity;
using TestWork.Runtime.Tools;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TestWork.Runtime.Core
{
    public sealed class BootstrapScope : LifetimeScope
    {
        [SerializeField] private ScenesSet _scenes;

        protected override void Awake()
        {
            IsRoot = true;
            DontDestroyOnLoad(this);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder scope)
        {
            IScene meta = new UnitySceneWithMemoryAllocate(_scenes.Meta, _scenes.Empty);

            scope.RegisterInstance(meta);
            scope.RegisterEntryPoint<Bootstrap>();
        }
    }
}