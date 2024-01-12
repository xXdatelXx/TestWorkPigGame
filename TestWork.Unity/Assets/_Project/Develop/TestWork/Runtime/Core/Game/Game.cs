using TestWork.Engine.BehaviourTree;
using TestWork.Engine.Time;
using TestWork.Gameplay;
using UnityEngine;
using VContainer.Unity;

namespace TestWork.Runtime.Core
{
    public sealed class Game : IStartable, ITickable
    {
        private readonly IGameLoop _gameLoop;
        private IBehaviourState _archerState;

        public Game(IGameLoop gameLoop, IArcher archer)
        {
            _gameLoop = gameLoop;
            _archerState = new ArcherFindTarget(archer);
        }

        public void Start() =>
            _gameLoop.Start();

        public void Tick() =>
            _archerState = _archerState.Execute(Time.deltaTime);
    }
}