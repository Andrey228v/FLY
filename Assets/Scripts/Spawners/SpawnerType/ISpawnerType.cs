using Assets.Scripts.SpawnPositionType;
using System;

namespace Assets.Scripts.Spawners.SpawnerType
{
    public interface ISpawnerType<T>
    {
        public event Action Spawned;

        public ISpawnPosition SpawnPosition { get; }

        public T Spawn();
    }
}
