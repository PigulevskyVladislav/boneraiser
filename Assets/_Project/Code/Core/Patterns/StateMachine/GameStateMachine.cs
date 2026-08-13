using _Project.Code.Core.Patterns.StateMachine.States;
using _Project.Code.Infrastructure.Factories;
using _Project.Code.Infrastructure.ScriptableObjects.Prefabs;
using UnityEngine;

namespace _Project.Code.Core.Patterns.StateMachine
{
    public class GameStateMachine
    {
        private readonly UnityPrefabFactory _prefabFactory;
        private readonly CommonData _prefabs;
        private readonly GameObject _canvas;
        private IState _currentState;

        public GameStateMachine(UnityPrefabFactory prefabFactory, CommonData prefabs, GameObject canvas)
        {
            _prefabFactory = prefabFactory;
            _prefabs = prefabs;
            _canvas = canvas;
        }

        public void Run()
        {
            _currentState = new MainMenuState(_prefabFactory, _prefabs, _canvas);
            _currentState.Enter();
        }

        public void ChangeState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
