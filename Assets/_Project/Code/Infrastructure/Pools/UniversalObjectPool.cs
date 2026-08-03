using System;
using _Project.Code.Infrastructure.Utils;
using System.Collections.Generic;
using _Project.Code.Infrastructure.Pools.References;
using UnityEngine;


namespace _Project.Code.Infrastructure.Pools
{
    [Serializable]
    public class UniversalObjectPool : MonoBehaviour, IPool
    {
        [SerializeField] private Dictionary<PoolType, GameObject> _containerMap;
        
        private readonly Dictionary<GameObject, Stack<GameObject>> _pools = new();

        public void SetContainerMap(Dictionary<PoolType, GameObject> containerMap)
        {
            _containerMap = containerMap;
        }

        public GameObject Get(GameObject prefab)
        {
            Debug.Assert(prefab != null);
            
            if (!_pools.ContainsKey(prefab))
            {
                _pools.Add(prefab, new Stack<GameObject>());
            }

            Stack<GameObject> pool = _pools[prefab];
            GameObject obj;

            if (pool.Count > 0)
            {
                obj = pool.Pop();
            }
            else
            {
                obj = Instantiate(prefab);				

                var prefabRef = obj.GetComponent<PrefabReference>();
                if (prefabRef == null)
                {
                    prefabRef = obj.AddComponent<PrefabReference>();
                }
                prefabRef.Initialize(prefab);
            }

            obj.transform.SetParent(null);
            return obj;
        }

        public void Return(GameObject obj)
        {
            Debug.Assert(obj != null);
            
            var isValid = true;
            
            if (!obj.TryGetComponent<PrefabReference>(out var prefabRef) 
                || !_pools.ContainsKey(prefabRef.SourcePrefab))
            {
                DevLogger.Fail($"Object {obj.name} returned to pool without PrefabReference!");
                isValid = false;
            }

            if (obj.TryGetComponent<PoolTypeReference>(out var containerRef))
            {
                DevLogger.Fail($"Object {obj.name} returned to pool without ContainerReference!");
            }

            if (!isValid)
            {
                Destroy(obj);
                return;
            }

            obj.SetActive(false);
            _pools[prefabRef.SourcePrefab].Push(obj);
            var poolType = containerRef != null ? containerRef.ContainerType : PoolType.Default;
            obj.transform.SetParent(_containerMap[poolType].transform);
        }
    }
}
