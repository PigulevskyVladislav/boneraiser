using UnityEngine;

namespace _Project.Code.Infrastructure.Pools.References
{
    [DisallowMultipleComponent]
    public class PrefabReference : MonoBehaviour
    {
        public GameObject SourcePrefab { get; private set; }
        
        public void Initialize(GameObject sourcePrefab)
        {
            if (sourcePrefab == null) return;

            SourcePrefab = sourcePrefab;
        }
    }
}
