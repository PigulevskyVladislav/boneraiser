using UnityEngine;

namespace _Project.Code.Core.Interfaces
{
    public interface IPrefabFactory
    {
        GameObject Spawn(GameObject prefab);
    
        void Despawn(GameObject prefab);
    }
}
