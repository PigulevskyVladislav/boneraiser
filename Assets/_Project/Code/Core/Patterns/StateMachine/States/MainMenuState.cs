using _Project.Code.Infrastructure.Factories;
using _Project.Code.Infrastructure.ScriptableObjects.Prefabs;
using UnityEngine;

namespace _Project.Code.Core.Patterns.StateMachine.States
{
    public class MainMenuState: IState
    {
        private readonly UnityPrefabFactory _prefabFactory;
        private readonly CommonData _prefabs;
        private readonly GameObject _canvas;
        private GameObject _mainMenu;
    
        public MainMenuState(UnityPrefabFactory prefabFactory, CommonData prefabs, GameObject canvas)
        {
            _prefabFactory = prefabFactory;
            _prefabs = prefabs;
            _canvas = canvas;
        }

        public void Enter()
        {
            _mainMenu = _prefabFactory.Spawn(_prefabs.MainMenu);
            _mainMenu.transform.SetParent(_canvas.transform, false);
        }

        public void Exit()
        {
            _prefabFactory.Despawn(_mainMenu);
        }
    }
}
