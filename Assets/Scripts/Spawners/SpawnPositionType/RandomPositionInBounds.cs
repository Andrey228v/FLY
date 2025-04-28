using System;
using UnityEngine;

namespace Assets.Scripts.SpawnPositionType
{
    [RequireComponent(typeof(Collider2D))]
    public class RandomPositionInBounds : MonoBehaviour, ISpawnPosition
    {
        private Vector3 _bounds;

        public event Action SetedPointForSpawn;

        public void Awake()
        {
            _bounds = GetComponent<Collider2D>().bounds.extents;
        }

        public Vector3 GetSpawnPosition()
        {
            float x = transform.position.x;
            float y = UnityEngine.Random.Range(-_bounds.y + transform.position.y, _bounds.y + transform.position.y);
            float z = transform.position.z;

            return new Vector3(x, y, z);
        }

        public void SetPoinForSpawn(Transform Point)
        {
            SetedPointForSpawn?.Invoke();
        }
    }
}
