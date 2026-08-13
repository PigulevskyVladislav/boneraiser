using System;
using System.Collections.Generic;
using _Project.Code.Core.Patterns.StateMachine;
using _Project.Code.Infrastructure.Factories;
using _Project.Code.Infrastructure.Pools;
using _Project.Code.Infrastructure.ScriptableObjects.Prefabs;
using UnityEngine;

namespace _Project.Code.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CommonData _prefabs;
        [SerializeField] private GameObject _canvas;

        private void Start()
        {
            var prefabFactory = LoadFactory(gameObject);
            var stateMachine = new GameStateMachine(prefabFactory, _prefabs, _canvas);
            stateMachine.Run();
        }

        private static UnityPrefabFactory LoadFactory(GameObject context)
        {
            var poolMap = CreatePoolContainers();
            var universalPool = context.AddComponent<UniversalObjectPool>();
            universalPool.SetContainerMap(poolMap);

            var prefabFactory = context.AddComponent<UnityPrefabFactory>();
            prefabFactory.SetPool(universalPool);
        
            return prefabFactory;
        }

        private static Dictionary<PoolType, GameObject> CreatePoolContainers()
        {
            var pool = new Dictionary<PoolType, GameObject>();
            var poolCount = Enum.GetNames(typeof(PoolType)).Length;
            for (var i = 0; i < poolCount; i++)
            {
                pool.Add((PoolType)i, new GameObject(((PoolType)i).ToString() + "Pool"));    
            }
            return pool;
        }
    }
}
