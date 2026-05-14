using UnityEngine;

namespace _Project.Code.Infrastructure.Utils
{
    public static class DevLogger
    {
        public static void Fail(string message, Object context = null)
        {
            var finalMessage = $"[FAIL] {message}";
            
            Debug.LogError(finalMessage, context);
            
            #if UNITY_EDITOR
            Debug.Assert(false, finalMessage, context);
            #endif
        }
    }
}
