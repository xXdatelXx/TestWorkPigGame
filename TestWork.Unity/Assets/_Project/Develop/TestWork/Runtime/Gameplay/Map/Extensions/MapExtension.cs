using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestWork.Gameplay
{
    public static class MapExtension
    {
        public static IReadOnlyList<TObject> FindInRadius<TObject>(this IMap<TObject> map, Transform center,
            float radius)
            where TObject : MonoBehaviour
        {
            var objects = map.Find().ToList();
            var inRadius = new List<TObject>(objects.Where(o =>
                Vector2.Distance(o.transform.position, center.position) <= radius));

            return inRadius;
        }

        public static TObject FindNearest<TObject>(this IMap<TObject> map, Transform center)
            where TObject : MonoBehaviour
        {
            var objects = map.Find().ToList();

            return objects.Count == 0
                ? default
                : objects.OrderBy(o => Vector3.Distance(center.transform.position, o.transform.position)).First();
        }
    }
}