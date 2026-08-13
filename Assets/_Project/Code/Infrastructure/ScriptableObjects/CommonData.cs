using System;
using UnityEngine;

namespace _Project.Code.Infrastructure.ScriptableObjects.Prefabs
{
    [CreateAssetMenu(fileName = "CommonData", menuName = "Scriptable Objects/CommonData")]
    [Serializable]
    public class CommonData : ScriptableObject
    {
        [Header("UI")]
        [field: SerializeField] public GameObject MainMenu { get; private set; }
    }
}
