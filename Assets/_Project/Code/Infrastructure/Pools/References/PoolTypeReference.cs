using UnityEngine;

namespace _Project.Code.Infrastructure.Pools.References
{
    [DisallowMultipleComponent]
    public class PoolTypeReference: MonoBehaviour
    {
        public PoolType ContainerType { get; private set; }

        public void Initialize(PoolType containerType)
        {
            ContainerType = containerType;
        }
    }
}
