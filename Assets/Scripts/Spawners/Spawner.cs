using Assets.Scripts.Spawners.ObjectsPools;
using Assets.Scripts.Spawners.SpawnerType;
using UnityEngine;

namespace Assets.Scripts.Spawners
{
    public class Spawner<T> : MonoBehaviour where T : Component, ISpawnObject<T>
    {
        public ISpawnerType<T> SpawnerType { get; private set; }
        public ObjectPoolPrefab<T> PoolFigure { get; private set; }

        private void Awake()
        {
            SpawnerType = GetComponent<ISpawnerType<T>>();
            PoolFigure = GetComponent<ObjectPoolPrefab<T>>();
        }
    }
}
