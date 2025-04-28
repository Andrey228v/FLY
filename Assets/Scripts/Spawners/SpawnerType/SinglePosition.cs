using Assets.Scripts.Spawners.ObjectsPools;
using Assets.Scripts.SpawnPositionType;
using System;
using UnityEngine;

namespace Assets.Scripts.Spawners.SpawnerType
{
    [RequireComponent(typeof(ISpawnPosition))]
    public class SinglePosition<T> : MonoBehaviour, ISpawnerType<T> where T : Component, ISpawnObject<T>
    {
        private ObjectPoolPrefab<T> _poolFigure;
        
        public event Action Spawned;

        public ISpawnPosition SpawnPosition { get; private set; }

        private void Awake()
        {
            SpawnPosition = GetComponent<ISpawnPosition>();
            _poolFigure = GetComponent<ObjectPoolPrefab<T>>();
        }

        public T Spawn()
        {
            T spawnObject = _poolFigure.Pool.Get();
            Vector3 position = SpawnPosition.GetSpawnPosition();
            spawnObject.transform.position = position;
            Spawned?.Invoke();

            return spawnObject;
        }
    }
}
