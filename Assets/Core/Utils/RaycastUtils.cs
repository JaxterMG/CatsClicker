using UnityEngine;

namespace BT.Core.Utils
{
    public class RaycastTarget : MonoBehaviour { }

    public static class RaycastUtils
    {
        private static readonly RaycastHit[] _cache = new RaycastHit[5];

        public static Transform Raycast3DScreenSpace<T>
            (this Camera camera, Vector2 screenPoint, int layer)
            where T : RaycastTarget
        {
            Ray position = camera.ScreenPointToRay(screenPoint);

            var hits = Physics.RaycastNonAlloc
            (
                position,
                _cache,
                1000f,
                1 << layer
            );
            for (var i = 0; i < hits; i++)
            {
                var hit = _cache[i];

                if (hit.collider == null) continue;
                if (hit.transform.GetComponent<T>() == null) continue;

                Debug.Log($"collider {hit.transform.gameObject.name} exist, component {typeof(T)} exist");

                return hit.transform;
            }

            return null;
        }
    }
}