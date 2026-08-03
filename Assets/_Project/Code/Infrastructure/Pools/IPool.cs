using UnityEngine;

namespace _Project.Code.Infrastructure.Pools
{
    public interface IPool
    {
        GameObject Get(GameObject prefab);
        
        void Return(GameObject obj);
    }
}
