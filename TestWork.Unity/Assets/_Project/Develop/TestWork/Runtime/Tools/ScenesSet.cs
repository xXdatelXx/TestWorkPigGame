using System;
using TestWork.Engine.Unity;
using UnityEngine;

namespace TestWork.Runtime.Tools
{
    [CreateAssetMenu(menuName = "TestWork/Scenes/Set", fileName = nameof(ScenesSet))]
    public sealed class ScenesSet : ScriptableObject, IScenesSet, ISerializationCallbackReceiver
    {
        [SerializeField] private UnityScene _meta;
        [SerializeField] private UnityScene _game;
        [SerializeField] private UnityScene _empty;

        public IScene Meta => _meta;
        public IScene Game => _game;
        public IScene Empty => _empty;

        public void OnBeforeSerialize()
        {
            if (Meta is null || Game is null || Empty is null)
                throw new NullReferenceException("Scene sets is not full");
        }

        public void OnAfterDeserialize()
        { }
    }
}