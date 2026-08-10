using System;
using _Project.Code.Core.Interfaces;
using _Project.Code.Infrastructure.Pools;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace _Project.Code.Infrastructure.Factories
{
    [Serializable]
    public class UnityPrefabFactory : MonoBehaviour, IPrefabFactory
    {
        [Header("Dependencies")]
        [SerializeField] private UniversalObjectPool _pool;

        [Header("Options")] 
        [SerializeField] private Transform _storageRoot;
        [SerializeField] private Vector3 _defaultPosition = Vector3.zero;
        [SerializeField] private Quaternion _defaultRotation =  Quaternion.identity;

        public void SetPool(UniversalObjectPool pool)
        {
            _pool = pool;
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            Debug.Assert(prefab != null);            
            
            GameObject obj;
            
            if (prefab.GetComponent<IPoolable>() == null)
            {
                obj = Instantiate(prefab);
            }
            else
            {
                obj = _pool.Get(prefab);
            }
            
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }

        public GameObject Spawn(GameObject prefab)
        {
            Debug.Assert(prefab != null);
            
            return Spawn(prefab, _defaultPosition, _defaultRotation);
        }

        public void Despawn(GameObject obj)
        {
            Debug.Assert(obj != null);
            
            if (obj.GetComponent<IPoolable>() == null)
            {
                Destroy(obj);
            }
            else
            {
                _pool.Return(obj);
            }
        }
    }
}
