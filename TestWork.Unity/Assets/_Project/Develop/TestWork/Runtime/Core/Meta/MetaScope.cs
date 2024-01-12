using TestWork.Engine.Unity;
using TestWork.Runtime.Tools;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TestWork.Runtime.Core
{
    public sealed class MetaScope : LifetimeScope
    {
        [SerializeField] private ScenesSet _scenes;

        protected override void Configure(IContainerBuilder scope)
        {
            IScene game = new UnitySceneWithMemoryAllocate(_scenes.Game, _scenes.Empty);

            scope.RegisterInstance(game);
            scope.RegisterEntryPoint<Meta>();
        }
    }
}